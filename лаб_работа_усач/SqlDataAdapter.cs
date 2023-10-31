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
        List<string> sql = new List<string>() {"SELECT * FROM T","SELECT * FROM T Where Name =" ,"UPDATE T SET Teacher = where FirstName = ", "DELETE FROM T where FirstName =  " , "insert into T Values (1,2,3,4)", "insert into T Values (1,2,3)" };


        public void Adapter(int i,string connectionString_)
        {
            using(SqlConnection connection = new SqlConnection(connectionString_))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(connectionString_, sql[i]);
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

            }
        }
    }
}
