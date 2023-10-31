using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаб_работа_усач
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conection conection = new Conection();
            textBox1.Text = conection.Con("Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
