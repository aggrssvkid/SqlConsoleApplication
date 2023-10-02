using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleSQLApp.Classes
{
    class CreateDB
    {
        static string createCmd = "CREATE TABLE Persons (FIO NVARCHAR(256) NULL, " +
            "Birthday DATE NULL, Gender NVARCHAR(1) NULL)";

        // Создаем простеннькую таблицу из трех столбцов. В c# для операций с БД существует пространство имен System.Data.SqlClient
        // Создаем экземпляр типа SqlCommand для выполнения Sql запросов и в качестве аргументов кидаем туда запрос и объекст подключения с бд.
        public static void CreateTable(SqlConnection connection)
        {
            try
            {
                SqlCommand command = new SqlCommand(createCmd, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("DB CREATED!");
            }
            catch
            {
                Console.WriteLine("We got exception!. DB not created!");
            }  
        }
    }
}
