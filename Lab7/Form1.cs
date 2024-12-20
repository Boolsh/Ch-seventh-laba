using System.Text;
using System.Windows.Forms;

namespace Lab7
{
    public partial class list_of_studentsForm : Form
    {
        public list_of_studentsForm() {InitializeComponent();}

        

        private AllStudents list_of_students = new AllStudents();

        private string fileName = string.Empty;
        private enum FileType
        {
            None, Txt, Bin, Xml
        }

        private FileType fileType = FileType.None;

        private int selectedNumber = -1;

        private void openToolStripMenuItem_Click(object sender, EventArgs e) //открытие файла
        {
            ResultTextBox.Clear();
            list_of_students = new AllStudents();
            var dlg = new OpenFileDialog();
            dlg.Filter = "Text (*.txt)|*.txt|Binary (*.bin)|*.bin|XML (*.xml)|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                var extension = fileName.Substring(fileName.LastIndexOf("."));
                switch (extension)
                {
                    case ".txt":
                        fileType = FileType.Txt;
                        list_of_students.OpenTxtFile(fileName);
                        ShowList();
                        break;

                    case ".bin":
                        fileType = FileType.Bin;
                        list_of_students.OpenBinFile(fileName);
                        ShowList();
                        break;

                    case ".xml":
                        fileType = FileType.Xml;
                        list_of_students.OpenXmlFile(fileName);
                        ShowList();
                        break;

                    default:
                        break;
                }
            }
        }

        private void ShowList(int index = 0) //Удаляет существующие элементы из списка, начиная с указанного индекса, и добавляет новых
        {
            var cnt = listBox_of_students.Items.Count;
            for (var i = cnt - 1; i >= index; --i)
            {
                listBox_of_students.Items.RemoveAt(i);
            }
            for (var i = index; i < list_of_students.Students.Count; i++)
                listBox_of_students.Items.Add((i + 1).ToString() + ". " + list_of_students.Students[i].ToListBox());
            listBox_of_students.Enabled = true;
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e) //инициализирует новый список студентов и создает пустой файл, очищает список студентов
        {
            var dlg = new SaveFileDialog();
            dlg.DefaultExt = ".txt";
            list_of_students = new AllStudents();
            fileName = String.Empty;
            if (dlg.ShowDialog() != DialogResult.Cancel)
            {
                fileName = dlg.FileName;
                StreamWriter f_out = new StreamWriter(fileName, false, Encoding.UTF8); ;
                f_out.Close();
                listBox_of_students.Items.Clear();
                MessageBox.Show("Файл успешно создан");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) // В зависимости от типа файла вызывает соответствующий метод сохранения из класса AllStudents.
                                                                             // Если файл еще не был сохранен, вызывает метод создания нового файла.

        {
            switch (fileType)
            {
                case FileType.None:
                    createToolStripMenuItem_Click(sender, e);
                    break;

                case FileType.Txt:
                    list_of_students.SaveTxtFile(fileName);
                    MessageBox.Show($"Файл {fileName.Substring(fileName.LastIndexOf("\\") + 1)} успешно сохранён");
                    break;

                case FileType.Xml:
                    list_of_students.SaveXmlFile(fileName);
                    MessageBox.Show($"Файл {fileName.Substring(fileName.LastIndexOf("\\") + 1)} успешно сохранён");
                    break;

                case FileType.Bin:
                    list_of_students.SaveBinFile(fileName);
                    MessageBox.Show($"Файл {fileName.Substring(fileName.LastIndexOf("\\") + 1)} успешно сохранён");
                    break;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) //в зависимости от выбранного типа файла вызывает соответствующий метод для сохранения данных.
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Text (*.txt)|*.txt|Binary (*.bin)|*.bin|XML (*.xml)|*.xml";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                var extension = fileName.Substring(fileName.LastIndexOf("."));
                switch (extension)
                {
                    case ".txt":
                        fileType = FileType.Txt;
                        list_of_students.SaveTxtFile(fileName);
                        break;

                    case ".bin":
                        fileType = FileType.Bin;
                        list_of_students.SaveBinFile(fileName);
                        break;

                    case ".xml":
                        fileType = FileType.Xml;
                        list_of_students.SaveXmlFile(fileName);
                        break;

                    default:
                        break;
                }
            }
        }

        private void taskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultTextBox.Clear();
            string subject = Microsoft.VisualBasic.Interaction.InputBox("Введите предмет:", "Предмет", "Мат. Анализ");

            string result = list_of_students.Task(subject);

            ResultTextBox.Text = result;
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e) //Открывает форму для ввода данных о студенте
        {
            var form = new StudentForm();
            form.ShowDialog();
            if (form.Changed)
            {
                list_of_students.Students.Add(StudentForm.student);
                selectedNumber = list_of_students.Students.Count - 1;
                listBox_of_students.Items.Add((selectedNumber + 1).ToString() +
                    ". " + list_of_students.Students[selectedNumber].ToListBox());
            }
            if (ResultTextBox.Text != "")
                taskToolStripMenuItem_Click(sender, e);
        }

        private void listBox_of_students_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedNumber = listBox_of_students.SelectedIndex;
            if (selectedNumber >= 0)
            {
                var student = list_of_students.Students[selectedNumber];
                var form = new StudentForm(student);
                form.ShowDialog();
                if (form.Changed)
                {
                    list_of_students.Students[selectedNumber] = StudentForm.student;
                    ShowList(selectedNumber);
                }
                listBox_of_students.SelectedIndex = -1;
                if (ResultTextBox.Text != "")
                    taskToolStripMenuItem_Click(sender, e);
            }
        }
        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = Microsoft.VisualBasic.Interaction.InputBox("Введите номер сутдента", "удаление", "1"); ;
            if (s != String.Empty)
            {
                int index = int.Parse(s) - 1;
                if (index < listBox_of_students.Items.Count && index >= 0)
                {
                    list_of_students.Students.RemoveAt(index);
                    ShowList(index);
                    if (ResultTextBox.Text != "")
                        taskToolStripMenuItem_Click(sender, e);
                }
                else
                    MessageBox.Show("Недопустимый номер студента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       


    }
}