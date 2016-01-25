using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Helpers;
using NLog;

namespace ClassLibrary.Mappers
{
    public abstract class BaseMapper<T> where T : class
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public abstract List<T> GetEntityList(string queryString);

        public int GetLastCreatedId(string queryString)
        {
            var resultId = 0;
            using (var table = DataBaseHelper.GetExecutionResult(queryString))
            {
                if (table.Rows.Count == 0) return resultId;
                try
                {
                    var type = table.Rows[0]["Id"].GetType();
                    if (type.Name != "DBNull")
                    {
                        resultId = Convert.ToInt32(table.Rows[0]["Id"]);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }
            }
            return resultId;
        }
    }
}
