using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаб_работа_усач
{
    public class SqlDataAdapter_
    {
        public DataSet Adapter(string connectionString_, string sql)
        {
            using(SqlConnection connection = new SqlConnection(connectionString_))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connectionString_);// выполняем запрос
                DataSet ds = new DataSet();// создаем объект датасет
                adapter.Fill(ds);// заполняем датасет
                return ds;// передаем датасет
            }
        }
    }
}
