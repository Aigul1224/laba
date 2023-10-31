using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace лаб_работа_усач
{

    public class Conection
    {
        public string Con(string stringconnection)
        {
            SqlConnection connection = new SqlConnection(stringconnection);
            try
            {
                connection.Open();
                connection.Close();
                return "Подключение закрыто";
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
            
        }
    }
}


