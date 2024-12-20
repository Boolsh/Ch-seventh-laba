using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Lab7
{

   
    public class AllStudents
    {
        public List<Student> Students = new List<Student>();
        public AllStudents() 
        {
            Students = new List<Student>();
        }

        public void OpenTxtFile(string fileName)
        {
            var sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                var student = new Student(sr);
                Students.Add(student);
            }

            sr.Close();
        }
       
        public void SaveTxtFile(string fileName)
        {
            using (var  sw = new StreamWriter(fileName))
            {
                foreach (var student in Students)
                    sw.WriteLine(student);
            }
        }

        public void OpenBinFile(string fileName)
        {
            var binFormatter = new BinaryFormatter();
            var file = new FileStream(fileName, FileMode.OpenOrCreate);
            try
            {
                Students = binFormatter.Deserialize(file) as List<Student>;
            }
            catch (Exception ex)
            {
                Students.Clear();
                MessageBox.Show(ex.Message, "Некорректный файл!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            { 
                file.Close(); 
            }
        }
        public void SaveBinFile(string fileName)
        {
            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, Students);
            }
        }

        public void OpenXmlFile(string fileName)
        {
            var xmlFormatter = new XmlSerializer(typeof(List<Student>));
            var file = new FileStream(fileName, FileMode.OpenOrCreate);
            try
            {
                Students = xmlFormatter.Deserialize(file) as List<Student>;
            }       
            catch (Exception ex)
            {
                Students.Clear();
                MessageBox.Show(ex.Message, "Некорректный файл!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                file.Close();
            }
        }

        public void SaveXmlFile(string fileName)
        {
            var xmlFormatter = new XmlSerializer(typeof(List<Student>));    
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, Students);
            }
        }

        public string Task(string subject)
        {
            var groupScores = new Dictionary<string, (int TotalMarks, int Count)>();

            // Сбор данных о оценках для каждой группы
            foreach (var student in Students)
            {
                foreach (var Ekzamen in student.Ekzamens)
                {
                    if (Ekzamen.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase))
                    {
                        string groupKey = $"{student.Course} курс, группа {student.Group}";
                        if (!groupScores.ContainsKey(groupKey))
                        {
                            groupScores[groupKey] = (0, 0);
                        }
                        groupScores[groupKey] = (groupScores[groupKey].TotalMarks + Ekzamen.Mark, groupScores[groupKey].Count + 1);
                    }
                }
            }

            // Переменные для хранения наилучших групп и их средней оценки
            var bestGroups = new List<string>();
            double bestAverage = 0;

            // Вычисление средней оценки для каждой группы
            foreach (var group in groupScores)
            {
                double average = (double)group.Value.TotalMarks / group.Value.Count;

                // Если текущая средняя оценка больше наилучшей, обновляем список
                if (average > bestAverage)
                {
                    bestAverage = average;
                    bestGroups.Clear(); // Очищаем список, так как мы нашли новую наилучшую среднюю оценку
                    bestGroups.Add(group.Key);
                }
                // Если средняя оценка равна наилучшей, добавляем группу в список
                else if (average == bestAverage)
                {
                    bestGroups.Add(group.Key);
                }
            }

            // Формирование результата
            if (bestGroups.Count > 0)
            {
                return $"Группы с наилучшей успеваемостью по предмету '{subject}': {string.Join(", ", bestGroups)} со средним баллом {bestAverage:F2}";
            }
            else
            {
                return $"Нет студентов, изучающих предмет '{subject}'.";
            }
        }
    }
}















































//        public void OpenTxtFile(string fileName)
//{
//    var sr = new StreamReader(fileName);
//    try
//    {
//        while (!sr.EndOfStream)
//        {
//            var student = new Student(sr);
//            Students.Add(student);
//        }
//    }
//    catch (FormatException ex)
//    {
//        Students.Clear();
//        MessageBox.Show("Числа в файле должны быть положительными цифрами", "Некорректный файл!", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//    catch (ArgumentOutOfRangeException ex) 
//    {
//        Students.Clear();
//        MessageBox.Show(ex.Message, "Некорректный файл!", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//    catch (IndexOutOfRangeException ex)
//    {
//        Students.Clear();
//        MessageBox.Show("Номер курса не соответствует количеству сессий", "Некорректный файл!", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//    catch (Exception ex) 
//    {
//        Students.Clear();
//        MessageBox.Show(ex.Message, "Некорректный файл!", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//    finally
//    { 
//        sr.Close(); 
//    }

//}
