using System.Collections.Generic;
using System.Data.SQLite;

namespace FBLA.Utils
{
    // DButils class provides data manipulation methods as utility functions for use throughout the application
    static class DButils
    {
        // the connection string to use for connecting to the FBLA Membership database
        private const string connectionString = @"data source='FBLAmembership.db'; Version=3;";

        // this function executes the supplied command, along with parameters, and returns the data as a DataAdapter object 
        public static SQLiteDataAdapter getDBData(string cmdText, List<SQLiteParameter> paramList) 
        {
            var cmd = openDBConnection();
            cmd.CommandText = cmdText;

            // Add any parameters that have been supplied for executing this command
            if (paramList != null && paramList.Count > 0)
            {
                foreach (var param in paramList)
                {
                    cmd.Parameters.Add(param);
                }
            }
            SQLiteDataAdapter ad = new SQLiteDataAdapter(cmd);
            return ad;
        }

        // this function executes the supplied command, along with parameters, to store data in the database
        public static bool storeData(string cmdText, List<SQLiteParameter> paramList)
        {
            SQLiteCommand cmd = openDBConnection();
            cmd.CommandText = cmdText;

            if (paramList != null && paramList.Count > 0)
            {
                foreach (var param in paramList)
                {
                    cmd.Parameters.Add(param);
                }
            }
            
            // ExecuteNonQuery is for executing queries that update, insert, or delete data
            int rowsAffected = cmd.ExecuteNonQuery();

            return (rowsAffected > 0);
        }

        // opens a connection to the database and returns the command object used to execute queries
        private static SQLiteCommand openDBConnection()
        {
             var connection = new SQLiteConnection(connectionString);
             connection.Open();

             SQLiteCommand cmd = connection.CreateCommand();
             return cmd;
        }

    }
}
