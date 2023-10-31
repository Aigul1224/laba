using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб_работа_усач
{
    public class SqlDataAdapter_
    {
        string connectionString_;
        string sql_;
        Dictionary<string, string> sql = new Dictionary<string, string>() { { "Select_all", "SELECT * FROM Users" }, { "Select_FirstName", "SELECT * FROM USERS Where Name =" }, { "Update_User", "UPDATE USERS SET Teacher = where FirstName = " }, { "Delete_User", "DELETE FROM USERS where FirstName =  " } };

        public SqlDataAdapter_(string connectionString, string sql)
        {
            connectionString_= connectionString;
            sql_ = sql;
        }

        public void Adapter(int n)
        {
            using(SqlConnection connection=new SqlConnection(connectionString_))
            {
                
                switch (n)
                {
                    case 1:
                        {
                            SqlDataAdapter adapter = new SqlDataAdapter(connectionString_);
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            foreach (DataTable dt in ds.Tables)
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    return;
                                }
                                foreach (DataRow row in dt.Rows)
                                {
                                    var cells = row.ItemArray;
                                    foreach (object cell in cells)
                                    {
                                        return;
                                    }

                                }

                                //Console.WriteLine($"{column.ColumnName}\t")
                            }
                            break;
                        }

                }
                

            }
        }
    }
}
