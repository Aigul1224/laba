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
    public partial class Form4 : Form
    {
        Conection conn = new Conection();
        SqlDataAdapter_ adapter = new SqlDataAdapter_();
        SqlCommand_ sqlCommand = new SqlCommand_();
        public Form4()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                adapter.Adapter(conn.stringConnection, sqlCommand.sql[5] + $"('{textBox1.Text}', '{textBox4.Text}','{textBox2.Text}', '{textBox3.Text}')");
                MessageBox.Show($"{textBox1.Text} {textBox4.Text} {textBox3.Text}", "Успешно создан");
            }
            catch
            {
                MessageBox.Show($"{textBox1.Text} {textBox4.Text} {textBox3.Text}", "Успешно не удалось создать");
            }
            
        }
    }
}
