using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    [Serializable]
    public class Ekzamen
    {       
        public string Subject { get; set; }
        private byte mark;
        public byte Mark { get; set; }
        public Ekzamen()
        {
            Subject = string.Empty;
            mark = 2;
        }
        public Ekzamen(string subject, byte mark)
        {
            Subject = subject;
            Mark = mark;
        }

        public override string ToString() 
        {
            return $"{Subject}: {mark}";
        }
    }

    [Serializable]
    public class Student
    {
        public enum EEducationForm { Budget, Contract }
        public string FIO { get; set; }
        private byte course;
        public byte Course
        {
            get { return course; }
            set
            {
                if (value < 1 || value > 4)
                    throw new ArgumentOutOfRangeException("Несуществующий номер курса");
                course = value;
            }
        }
        private byte group;
        public byte Group
        {
            get { return group; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Несуществующий номер группы");
                group = value;
            }
        }
        public Ekzamen[] Ekzamens { get; set; }
        public EEducationForm EducationForm { get; set; }
        static public readonly byte CountEkzamens = 5;
        static public readonly byte CountSessions = 8;
        public Student() 
        { 
            FIO = string.Empty;
            group = 1;
            course = 1;
            Ekzamens = new Ekzamen[CountEkzamens * CountSessions];
            for (var i = 0; i < Ekzamens.Length; ++i)
                Ekzamens[i] = new Ekzamen();
            EducationForm = EEducationForm.Contract;
        }
        public Student(string fio, byte n_course, byte n_group, Ekzamen[] n_Ekzamens, EEducationForm educationForm)
        {
            FIO = fio;
            course = n_course;
            group = n_group;
            Ekzamens = n_Ekzamens;
            EducationForm = educationForm;
        }
        public Student(StreamReader sr)
        {
            FIO = sr.ReadLine();
            Course = byte.Parse(sr.ReadLine());
            Group = byte.Parse(sr.ReadLine());

            int EkzamenNum = CountEkzamens * course * 2;
            Ekzamens = new Ekzamen[EkzamenNum];

            for (var i = 0; i < EkzamenNum; ++i)
            {
                var lines = sr.ReadLine().Split(':');
                var subject = lines[0];
                var mark = byte.Parse(lines[1].Trim());
                Ekzamens[i] = new Ekzamen(subject, mark);
            }
            if (sr.ReadLine().ToLower() == "бюджет")
            {
                EducationForm = EEducationForm.Budget;
            }
            else
            {
                EducationForm = EEducationForm.Contract;
            }
        }
        
        public string ToListBox()
        {
            return $"{FIO}, {course}-й курс, группа {group}, {(EducationForm == EEducationForm.Budget ? "бюджет" : "договор")}";
        }

        public override string ToString()
        {
            string result =  $"{FIO}\n{course}\n{group}\n";
            int EkzamenNum = course * CountEkzamens * 2;
            for (var i = 0; i < EkzamenNum; ++i)
                result += Ekzamens[i].ToString() + "\n";
            result += EducationForm == EEducationForm.Budget ? "Бюджет" : "Договор";
            return result;
        }
    }
}
