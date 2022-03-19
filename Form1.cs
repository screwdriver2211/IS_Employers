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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\ADC1337\Desktop\Kursach\Information\Employeers.txt"))
            {
                Form3 f = new Form3();
                f.Show();
            }
            else
            {
                MessageBox.Show("Заполните информацию!");
                return;
            }
        }
    }
    
}
