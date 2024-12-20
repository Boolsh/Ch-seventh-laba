namespace Lab7
{
    partial class list_of_studentsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox_of_students = new ListBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            createToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            addStudentToolStripMenuItem = new ToolStripMenuItem();
            deleteStudentToolStripMenuItem = new ToolStripMenuItem();
            taskToolStripMenuItem = new ToolStripMenuItem();
            textBox1 = new TextBox();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            ResultTextBox = new TextBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox_of_students
            // 
            listBox_of_students.FormattingEnabled = true;
            listBox_of_students.ItemHeight = 15;
            listBox_of_students.Location = new Point(12, 67);
            listBox_of_students.Name = "listBox_of_students";
            listBox_of_students.ScrollAlwaysVisible = true;
            listBox_of_students.Size = new Size(363, 469);
            listBox_of_students.TabIndex = 0;
            listBox_of_students.SelectedIndexChanged += listBox_of_students_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, addStudentToolStripMenuItem, deleteStudentToolStripMenuItem, taskToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(789, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.Image = Properties.Resources.slavaKPSS;
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.Size = new Size(184, 26);
            createToolStripMenuItem.Text = "Создать";
            createToolStripMenuItem.Click += createToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(184, 26);
            openToolStripMenuItem.Text = "Открыть";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(184, 26);
            saveToolStripMenuItem.Text = "Сохранить";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(184, 26);
            saveAsToolStripMenuItem.Text = "Сохранить как";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // addStudentToolStripMenuItem
            // 
            addStudentToolStripMenuItem.Name = "addStudentToolStripMenuItem";
            addStudentToolStripMenuItem.Size = new Size(111, 20);
            addStudentToolStripMenuItem.Text = "Добавить запись";
            addStudentToolStripMenuItem.Click += addStudentToolStripMenuItem_Click;
            // 
            // deleteStudentToolStripMenuItem
            // 
            deleteStudentToolStripMenuItem.Name = "deleteStudentToolStripMenuItem";
            deleteStudentToolStripMenuItem.Size = new Size(103, 20);
            deleteStudentToolStripMenuItem.Text = "Удалить запись";
            deleteStudentToolStripMenuItem.Click += deleteStudentToolStripMenuItem_Click;
            // 
            // taskToolStripMenuItem
            // 
            taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            taskToolStripMenuItem.Size = new Size(236, 20);
            taskToolStripMenuItem.Text = "Найти группу с наивысшим ср.баллом";
            taskToolStripMenuItem.Click += taskToolStripMenuItem_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.MenuBar;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(157, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 16);
            textBox1.TabIndex = 3;
            textBox1.Text = "Список студентов";
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(32, 19);
            // 
            // ResultTextBox
            // 
            ResultTextBox.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            ResultTextBox.Location = new Point(406, 67);
            ResultTextBox.Multiline = true;
            ResultTextBox.Name = "ResultTextBox";
            ResultTextBox.Size = new Size(365, 470);
            ResultTextBox.TabIndex = 4;
            // 
            // list_of_studentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 541);
            Controls.Add(ResultTextBox);
            Controls.Add(textBox1);
            Controls.Add(listBox_of_students);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "list_of_studentsForm";
            Text = "Students List";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox_of_students;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem addStudentToolStripMenuItem;
        private ToolStripMenuItem taskToolStripMenuItem;
        private TextBox textBox1;
        private ToolStripMenuItem deleteStudentToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private TextBox ResultTextBox;
    }
}