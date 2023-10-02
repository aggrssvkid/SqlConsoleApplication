using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleSQLApp.Classes
{
    class AddRow
    {
        // Добавляем запись в таблицу.
        public static int Insert(string cmd, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(cmd, connection);
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }
    }
}
