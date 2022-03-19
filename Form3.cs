using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Form3 : Form
    {
        DataTable dt;
        string filterField = "Фамилия";
        string filterField1 = "Работает удалённо";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader(@"C:\Users\ADC1337\Desktop\Kursach\Information\Employeers.txt");
            dt = new DataTable();
            
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Имя");
            dt.Columns.Add("ID");
            dt.Columns.Add("Должность");
            dt.Columns.Add("Работает удалённо");
            dt.Columns.Add("Количество отработанных часов");
            dt.Columns.Add("Зарплата, руб");
            dt.Columns.Add("Проект");

            string[] values;
            string newline; 
            while ((newline = file.ReadLine()) != null)
            {
                DataRow dr = dt.NewRow();    
                values = newline.Split(' ');
                for (int i = 0; i < values.Length; i++)
                {
                    dr[i] = values[i]; // присваиваем ячейкам строки
                }

                dt.Rows.Add(dr); // строку добавляем в таблицу
            }
            file.Close();
            // таблицу данных dt используем как DataSource для dataGridView1
            dataGridView1.DataSource = dt;
            // устанавливаем автоматическую ширину столбцов
            dataGridView1.AutoResizeColumns();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", filterField,textBox1.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dt.DefaultView.RowFilter = string.Format("[Работает удалённо] LIKE 'Да'", filterField1,dt);
            }
            else
            {
                dt.DefaultView.RowFilter = null;
            }
        }
    }
    
}
