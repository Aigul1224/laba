using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace лаб_работа_усач
{
    public partial class Form1 : Form
    {
        Conection conn = new Conection();
        SqlDataAdapter_ adapter = new SqlDataAdapter_();
        SqlCommand_ sqlCommand = new SqlCommand_();
        string listElement;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PresentTableSecond(adapter.Adapter(conn.stringConnection, sqlCommand.sql[4]));
            PresentTableFirst(adapter.Adapter(conn.stringConnection, sqlCommand.sql[0]));
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            listElement = comboBox1.Text;
            if (listElement == "")
            {
                MessageBox.Show("Вы не выбрали таблицу");
                return;
            }
            switch (listElement)
            {
                case "Учитель":
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                        break;
                    }
                case "Ученик":
                    {
                        Form4 form4 = new Form4();
                        form4.Show();
                        break;
                    }
            }
        }

        private void SelectByNumberClass_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                PresentTableFirst(adapter.Adapter(conn.stringConnection, sqlCommand.sql[0]));
                PresentTableSecond(adapter.Adapter(conn.stringConnection, sqlCommand.sql[4]));
            }
            else
            {
                PresentTableFirst(adapter.Adapter(conn.stringConnection, sqlCommand.sql[1] + "'" + textBox1.Text + "'"));
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            listElement = comboBox1.Text;
            if (listElement == "")
            {
                MessageBox.Show("Вы не выбрали таблицу");
                return;
            }
            switch (listElement)
            {
                case "Учитель":
                    {
                        try
                        {
                            DialogResult result = MessageBox.Show("ОБновить данные об учителе?","Предупреждение", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                            if(result == DialogResult.Yes)
                            {
                                adapter.Adapter(conn.stringConnection, $"use agul UPDATE Teachers SET Name = '{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString()}',LastName = '{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString()}', ClassNumber = '{dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString()}' where Id = {dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()}");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось обновить");
                        }
                        break;
                    }
                case "Ученик":
                    {
                        try
                        {
                            DialogResult result = MessageBox.Show("ОБновить данные об ученике?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                adapter.Adapter(conn.stringConnection, $"use agul UPDATE Students SET Name = '{dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[1].Value.ToString()}',LastName = '{dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString()}', FirstName = '{dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString()}', TeacherId = '{dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value.ToString()}' where Id = {dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString()}");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось обновить");
                        }
                        break;
                    }
            }
           
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            listElement = comboBox1.Text;
            if (listElement == "")
            {
                MessageBox.Show("Вы не выбрали таблицу");
                return;
            }
            switch (listElement)
            {
                case "Учитель":
                    {
                        try
                        {
                            adapter.Adapter(conn.stringConnection, sqlCommand.sql[2] + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
                            MessageBox.Show("Учитель удален");
                        }
                        catch
                        {
                            MessageBox.Show("Учителя не удалось удалить");
                        }

                        break;
                    }
                case "Ученик":
                    {
                        try
                        {
                            adapter.Adapter(conn.stringConnection, sqlCommand.sql[6] + dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString());
                            MessageBox.Show("Ученик удален");
                        }
                        catch
                        {
                            MessageBox.Show("Ученика не удалось удалить");
                        }
                        break;
                    }
            }
        }
        private void PresentTableFirst(DataSet table)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            foreach (DataTable dt in table.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                }
                // перебор всех строк таблицы
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    dataGridView1.Rows.Add(cells);
                }
            }
        }
        private void PresentTableSecond(DataSet table)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            foreach (DataTable dt in table.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    dataGridView2.Columns.Add(column.ColumnName, column.ColumnName);
                }
                // перебор всех строк таблицы
                foreach (DataRow row in dt.Rows)
                {
                    // получаем все ячейки строки
                    var cells = row.ItemArray;
                    dataGridView2.Rows.Add(cells);
                }
            }
        }
    }
}
