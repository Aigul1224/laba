using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace лаб_работа_усач
{
    public class SqlCommand_
    {
        public List<string> sql = new List<string>() { "SELECT * FROM Teachers", "SELECT * FROM Teachers Where ClassNumber = ",  "DELETE FROM Teachers where Id = ", "insert into Teachers (Name, LastName, ClassNumber) Values ", "SELECT * FROM Students","insert into Students (Name, LastName, FirstName,TeacherId) Values ", "DELETE FROM Students where Id = " };
        public void ExecuteSQLCommand(int i, string connectionString_)
        {
            using (SqlConnection connection = new SqlConnection(connectionString_))//транзакция 
            {
                connection.Open(); // открываем соединение с бд
                SqlCommand command = new SqlCommand();
                command.CommandText = sql[i]; // хранит команду sql
                command.Connection = connection;// используем подключение
                command.ExecuteNonQuery();// выполняем команду 
            }
        }
       
    }
}
