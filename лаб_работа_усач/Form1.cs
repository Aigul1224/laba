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
        Conection conn = new Conection();
        SqlDataAdapter_ adapter = new SqlDataAdapter_();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adapter.Adapter()
        }
    }
}
