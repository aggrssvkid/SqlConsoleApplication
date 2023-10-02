using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleSQLApp.Classes
{
    // cmd содержит весь необходимый код запроса. Объект "reader" может считать результат запроса, если мы того пожелаем.
    // Вывод происходит немножко не ровно, прошу прощения. Но логика работы программы не нарушается. Все данные с запроса выводятся на консоль.
    class SelectDatasTask3
    {
        private static string cmd = "declare @currentMoth int " +
                                    "declare @currentDay int " +
                                    "select @currentMoth = DATEPART(MONTH, GETDATE()) " +
                                    "select @currentDay = DATEPART(DAY, GETDATE()) " +
                                    "select distinct FIO, Birthday, Gender, " +
                                    "DATEDIFF(YEAR, Persons.Birthday, CAST (GETDATE() as date))  - CASE " +
                                    "WHEN(MONTH(Persons.Birthday) > @currentMoth OR (MONTH(Persons.Birthday) = @currentMoth AND DAY(Persons.Birthday) > @currentDay)) " +
                                    "THEN 1 ELSE 0 END " +
                                    "AS Age " +
                                    "from Persons " +
                                    "order by FIO";
        public static void PrintDatas(SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                for (int i = 0; i < 4; i++)
                    Console.Write($"{reader.GetName(i)}\t\t");
                Console.WriteLine("");
                while (reader.Read())
                {
                    var fio = reader.GetValue(0).ToString();
                    var birthday = (DateTime)reader.GetValue(1);
                    var gender = reader.GetValue(2).ToString();
                    var age = reader.GetValue(3).ToString();
                    Console.WriteLine($"{fio}\t{birthday.Day}.{birthday.Month}.{birthday.Year}\t{gender}\t{age}");
                }
            }
        }
    }
}
