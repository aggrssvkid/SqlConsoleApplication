using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleSQLApp.Classes
{
    class Add100000Rows
    {
        public static void AddRows(SqlConnection connection)
        {
            // Добавляем строки в таблицу, генерируя рандомные параметры. При желании, можно увеличить число добавленных строк,
            // задав нужное значение переменной rowsNum. Я добавил столько строк, поскольку слабоватый компуктер:) 
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            int rowsNum = 100000;
            int count = 0;
            for (int i = 0; i < rowsNum; i++)
            {
                string randomName = GetName(null);
                string randomDate = GetDate();
                string randomGender = GetGender();
                command.CommandText = $"INSERT INTO Persons (FIO, Birthday, Gender) VALUES ('{randomName}', '{randomDate}', '{randomGender}')";
                count += command.ExecuteNonQuery();
            }

            // Добавляем 100 рандомных мужиков, с фамилией, начинающейся на "F".
            for (int i = 0; i < 100; i++)
            {
                string randomName = GetName('F');
                string randomDate = GetDate();
                string Gender = "M";
                command.CommandText = $"INSERT INTO Persons (FIO, Birthday, Gender) VALUES ('{randomName}', '{randomDate}', '{Gender}')";
                count += command.ExecuteNonQuery();
            }
            Console.WriteLine($"Added {count} Rows");
        }

        // Function for random Name Generation
        private static string GetName(char? startSymbol)
        {
            Random r = new Random();
            StringBuilder name = new StringBuilder("");
            if (startSymbol != null)
                name.Append(startSymbol);
            for (int i = 0; i < 3; i++)
            {
                int length = r.Next(1, 11);
                StringBuilder str = new StringBuilder("");
                for (int j = 0; j < length; j++)
                {
                    char symbol = (char)('a' + r.Next(0, 26));
                    str.Append(symbol);
                }
                str[0] = char.ToUpper(str[0]);
                if (i != 2)
                    str.Append('_');  
                name.Append(str);
            }
            return name.ToString();
        }

        // Function for random Birthday generation
        // Первый идет месяц, потом день, потом год. Генерация дня идет до 25-го числа, дабы не увеличивать объЕм кода, который не влияет
        // на логику программы. Чтобы не выпадало такое, что у мужика дата рождения 31-го февраля...
        // Хотя SQL выдаст ошибку на стадии парсинга, если такое произойдет.
        private static string GetDate()
        {
            StringBuilder date = new StringBuilder("");
            Random r = new Random();
            string moth = r.Next(1, 13).ToString();
            date.Append(moth);
            date.Append('/');
            string day = r.Next(1, 25).ToString();
            date.Append(day);
            date.Append("/19");
            string year = r.Next(50, 100).ToString();
            date.Append(year);
            return date.ToString();
        }

        private static string GetGender()
        {
            Random r = new Random();
            int res = r.Next(0, 2);
            if (res == 0)
                return "F";
            else
                return "M";
        }
    }
}
