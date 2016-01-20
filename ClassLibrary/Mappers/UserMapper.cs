using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Helpers;
using NLog;

namespace ClassLibrary.Mappers
{
    public class UserMapper : IMapper<User>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<User> GetEntityList(string queryString)
        {
            var resultList = new List<User>();
            using (var table = DataBaseHelper.GetExecutionResult(queryString))
            {
                if (table.Rows.Count == 0) return null;
                try
                {
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var id = Convert.ToInt32(table.Rows[i]["Id"]);
                        var name = table.Rows[i]["Name"].ToString();
                        var address = table.Rows[i]["Address"].ToString();

                        var entity = new User(id, name, address);
                        resultList.Add(entity);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return null;
                }
            }
            return resultList;
        }
    }
}
