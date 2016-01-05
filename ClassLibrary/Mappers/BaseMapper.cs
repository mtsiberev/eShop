using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Helpers;
using NLog;

namespace ClassLibrary.Mappers
{
    public abstract class BaseMapper<T> where T : class
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected abstract T GetEntityFromReader(DataTableReader reader);

        public T GetEntity(string queryString)
        {
            try
            {
                using (var reader = DataBaseHelper.GetExecutionResult(queryString))
                {
                    return GetEntityFromReader(reader);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public List<T> GetEntityList(string queryString)
        {
            var resultList = new List<T>();

            try
            {
                using (var reader = DataBaseHelper.GetExecutionResult(queryString))
                {
                    if (!reader.HasRows) return null;
                    while (reader.Read())
                    {
                        var catalog = GetEntityFromReader(reader);
                        resultList.Add(catalog);
                    }
                    return resultList;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

    }
}
