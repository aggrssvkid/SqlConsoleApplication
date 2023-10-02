using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace ConsoleSQLApp.Classes
{
    class SelectDatasTask5
    {
        // запрос
        private static string cmd = @"select * from Persons where Gender LIKE 'M' AND FIO LIKE 'F%'";

        public static void QueryTime(SqlConnection connection)
        {
            // Stopwatch - объект в c# для измерения времени. Без создания кластеризованного индекса, идет обычнй table scan.
            // Время исполения запроса без оптимизации на моей железяке - 30 ms. С кластеризованным индексом по колонке FIO - 21
            // База данных со всеми записями приложена к проекту и находется в папке  databases. (Persons.mdf)
            SqlCommand command = new SqlCommand(cmd, connection);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var reader = command.ExecuteReader();   
            sw.Stop();
            Console.WriteLine($"Time spend on request execution: {sw.ElapsedMilliseconds} ms");
        }
    }
}
