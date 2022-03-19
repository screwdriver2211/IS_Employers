using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Form2 : Form
    {
        public string Name1;
        public string Surname1;
        public string Id1;
        public string Position1;
        public string WorkOn1 = "Нет";
        public int HoursOfWork1;
        public int Salary1;
        public string Project1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            project.Hide();
            label6.Hide();
            label7.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPicture = new OpenFileDialog();
            openPicture.Filter = "JPG|*.jpg;*.jpeg|PNG|*.png";
            if (openPicture.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openPicture.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void hours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text != string.Empty)
            {
                Name1 = name.Text;
            }
            else
            {
                MessageBox.Show("Заполните имя!");
                name.Focus();
                return;
            }

            if (surname.Text != string.Empty)
            {
                Surname1 = surname.Text;
            }
            else
            {
                MessageBox.Show("Заполните фамилию!");
                surname.Focus();
                return;
            }

            if (id.Text != string.Empty)
            {
                Id1 = id.Text;
            }
            else
            {
                MessageBox.Show("Введите ID!");
                id.Focus();
                return;
            }

            if (hours.Text != string.Empty)
            {
                HoursOfWork1 = Convert.ToInt32(hours.Text);
            }
            else
            {
                MessageBox.Show("Введите количество отработанных часов!");
                hours.Focus();
                return;
            }

            if (name.Text != string.Empty)
            {
                Name1 = name.Text;
            }
            else
            {
                MessageBox.Show("Заполните имя");
                name.Focus();
                return;
            }

            if(position.Text == "Босс")
            {
               
                Position1 = position.Text;
                if(project.Text != string.Empty)
                {
                    Project1 = project.Text;
                }
                else
                {
                    MessageBox.Show("Введите проект, которым руководит босс!");
                    project.Focus();
                    return;
                }
            }
            if (position.Text != "Выберите из списка")
            {
                Position1 = position.Text;
            }
            else
            {
                MessageBox.Show("Выберите должность сотрудника!");
                position.Focus();
                return;
            }
            if (Position1 == "Босс")
            {
                Boss boss = new Boss(Name1, Surname1, Id1, Position1, WorkOn1, HoursOfWork1, Project1);
                MessageBox.Show(boss.Info());
                String fileName = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Title = "Сохранить информацию";
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveFileDialog.FileName = @"C:\Users\ADC1337\Desktop\Kursach\Information\Employeers.txt";
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;// Сохранить имя файла
                    StreamWriter streamwriter = new StreamWriter(fileName, true, Encoding.GetEncoding("utf-8"));
                    streamwriter.WriteLine(boss.Info());

                    streamwriter.Close();

                    pictureBox1.Image.Save(@"C:\Images\" + surname.Text + ".jpg");
                }
            }
            else
            {
                Employee employee = new Employee(Name1, Surname1, Id1, Position1, WorkOn1, HoursOfWork1);
                MessageBox.Show(employee.Info());
                String fileName = "";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Title = "Сохранить информацию";
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
                saveFileDialog.FileName = @"C:\Users\ADC1337\Desktop\Kursach\Information\Employeers.txt";
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;// Сохранить имя файла
                    StreamWriter streamwriter = new StreamWriter(fileName, true, Encoding.GetEncoding("utf-8"));
                    streamwriter.WriteLine(employee.Info());

                    streamwriter.Close();

                    pictureBox1.Image.Save(@"C:\Images\" + surname.Text + ".jpg");
                }
            }
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                WorkOn1 = "Да";
            }
        }

        private void position_SelectedValueChanged(object sender, EventArgs e)
        {
            if(position.Text == "Босс")
            {
                label6.Show();
                project.Show();
                label7.Text = "Ставка за час: 350 рублей";
                label7.Show();
            }
            if(position.Text == "Сотрудник")
            {
                label7.Text = "Ставка за час: 150 рублей";
                label7.Show();
                label6.Hide();
                project.Hide();
            }
        }
    }
}
