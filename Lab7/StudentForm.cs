using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class StudentForm : Form
    {

        public static Student student { get; set; }
        private bool is_changed = false;
        public bool Changed { get { return is_changed; } }
        private bool is_edit; // открыта ли форма для редактирования существующего студента (true) или для добавления нового (false).
        public StudentForm()
        {
            InitializeComponent();
            StudentForm.student = new Student();
            this.is_edit = false;
        }
        public StudentForm(Student student)
        {
            InitializeComponent();
            StudentForm.student = student;
            this.is_edit = true;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (number != 8 && !char.IsDigit(number))
                e.Handled = true;
        }
        private void StudentForm_Load(object sender, EventArgs e)
        {
            academPerfomanceGrid.Rows.Clear();
            if (is_edit)
            {
                OpenForEditing();
            }
        }

        private void OpenForEditing() //заполняет поля формы данными студента, если форма открыта для редактирования
        {
            textBoxFIO.Text = student.FIO;
            textBoxGroup.Text = student.Group.ToString();
            switch (student.Course)
            {
                case 1:
                    radioButton1.Checked = true;
                    break;
                case 2:
                    radioButton2.Checked = true;
                    break;
                case 3:
                    radioButton3.Checked = true;
                    break;
                case 4:
                    radioButton4.Checked = true;
                    break;
            }
            if (student.EducationForm == Student.EEducationForm.Budget)
                radioButtonBudget.Checked = true;
            else
                radioButtonContract.Checked = true;
            int EkzamenNum = student.Course * Student.CountEkzamens * 2;
            for (int i = 0; i < EkzamenNum; i++)
            {
                academPerfomanceGrid.Rows[i].Cells[2].Value = student.Ekzamens[i].Subject;
                academPerfomanceGrid.Rows[i].Cells[3].Value = student.Ekzamens[i].Mark.ToString();
            }
        }
        private bool SaveStudent() //Проверяет корректность введенных данных
        {
            student.FIO = textBoxFIO.Text;
            var group = textBoxGroup.Text;
            if (group[0] == '0')
            {
                MessageBox.Show("Номер группы является положительным числом", "Ошибка в номере группы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            student.Group = byte.Parse(group);
            if (radioButton1.Checked)
                student.Course = 1;
            else
                if (radioButton2.Checked)
                student.Course = 2;
            else
                    if (radioButton3.Checked)
                student.Course = 3;
            else
                student.Course = 4;
            if (radioButtonBudget.Checked)
                student.EducationForm = Student.EEducationForm.Budget;
            else
                student.EducationForm = Student.EEducationForm.Contract;
            int EkzamenNum = student.Course * Student.CountEkzamens * 2;
            student.Ekzamens = new Ekzamen[EkzamenNum];
            for (var i = 0; i < EkzamenNum; ++i)
            {
                student.Ekzamens[i] = new Ekzamen();
                string s = academPerfomanceGrid.Rows[i].Cells[2].Value.ToString();
                if (s == String.Empty)
                {
                    MessageBox.Show("Введите названия предметов", "Ошибка в DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                student.Ekzamens[i].Subject = s;
                s = academPerfomanceGrid.Rows[i].Cells[3].Value.ToString();
                if (s == String.Empty || !byte.TryParse(s, out byte mark) || mark < 2 || mark > 5)
                {
                    MessageBox.Show("Оценки должны быть целым числом в диапазоне [2; 5]", "Ошибка в DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                student.Ekzamens[i].Mark = mark;
            }
            return true;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e) //Определяет количество экзаменов в зависимости от выбранного курса
                                                                            //и добавляет соответствующее количество строк в academPerfomanceGrid
        {
            int course = Convert.ToInt32(((RadioButton)sender).Text);
            int EkzamenNum = course * Student.CountEkzamens * 2;
            for (var i = academPerfomanceGrid.Rows.Count; i < EkzamenNum; ++i)
            {
                academPerfomanceGrid.Rows.Add();
                if (i % 10 == 0)
                    academPerfomanceGrid.Rows[i].Cells[0].Value = (i / 10 + 1).ToString();
                if (i % 5 == 0)
                    academPerfomanceGrid.Rows[i].Cells[1].Value = (i / 5 + 1).ToString();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (SaveStudent())
            {
                is_changed = true;
                this.Close();
            }
        }
    }
}
