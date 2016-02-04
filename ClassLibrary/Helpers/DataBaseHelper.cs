using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NLog;

namespace ClassLibrary.Helpers
{
    public class DataBaseHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static string GetConnectionString()
        {
            return ConfigurationManager.
              ConnectionStrings["ConnectionString"].ConnectionString;
        }
        
        public static DataTable GetExecutionResult(string queryString)
        {
            var table = new DataTable();
            using (var connection = new SqlConnection())
            {
                try
                {
                    connection.ConnectionString = GetConnectionString();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return table;
                }

                using (var adapter = new SqlDataAdapter(queryString, connection))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        return table;
                    }

                    try
                    {
                        adapter.Fill(table);
                        return table;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        return table; 
                    }
                }
            }
        }

        public static void ExecuteCommand(string queryString)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return;
                }

                using (var command = new SqlCommand(queryString, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.Message);
                        return;
                    }
                    logger.Trace("SqlCommand: {0} successfully completed", queryString);
                }
            }
        }

    }
}
