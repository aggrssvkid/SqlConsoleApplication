using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ConsoleSQLApp.Classes;

namespace ConsoleSQLApp
{
    class Program
    {
        static private SqlConnection connection = null;
        static void Main(string[] args)
        {
            // Так как приложение основано на работе с БД, то подключаемся к бд и проверяем, успешнно ли завершилось подключение.
            // Если подключиться не удалось, то сообщаем об этом клиенту через консоль и закрываем приложение.
            // В файле конфига приложения описана строка подключения, через которую подрубаемся к бд.
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonsDB"].ConnectionString);
            connection.Open();
            if (connection.State != ConnectionState.Open)
            {
                Console.WriteLine("Cant connect to DataBase.");
                return;
            }

            // Далее проверяем входные данные командной строки при запуске приложения. При соответсвующих аргументах
            // командной строки вызыватся соответсвующая функция в коде по заданию.
            if (args.Length == 1 && args[0] == "1")
                CreateDB.CreateTable(connection);
            else if (args.Length == 4 && args[0] == "2")
            {
                string cmd = $"INSERT INTO Persons (FIO, Birthday, Gender) VALUES ('{args[1]}', '{args[2]}', '{args[3]}')";
                int rowsAdded = AddRow.Insert(cmd, connection);
                Console.WriteLine($"RowsAdded:{rowsAdded}");
            }
            else if (args.Length == 1 && args[0] == "3")
                SelectDatasTask3.PrintDatas(connection);
            else if (args.Length == 1 && args[0] == "4")
                Add100000Rows.AddRows(connection);
            else if (args.Length == 1 && args[0] == "5")
                SelectDatasTask5.QueryTime(connection);
            connection.Close();
        }
    }
}


