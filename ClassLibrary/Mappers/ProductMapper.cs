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
    public class ProductMapper : IMapper<Product>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<Product> GetEntityList(string queryString)
        {
            var resultList = new List<Product>();
            using (var table = DataBaseHelper.GetExecutionResult(queryString))
            {
                if (table.Rows.Count == 0) return null;
                try
                {
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var id = Convert.ToInt32(table.Rows[i]["Id"]);

                        var catalogId = 0;
                        var type = table.Rows[i]["catalogId"].GetType();
                        if (type.Name != "DBNull")
                        {
                            catalogId = Convert.ToInt32(table.Rows[i]["catalogId"]);
                        }

                        var name = table.Rows[i]["Name"].ToString();

                        var description = "";
                        type = table.Rows[i]["Description"].GetType();
                        if (type.Name != "DBNull")
                        {
                            description = table.Rows[i]["Description"].ToString();
                        }

                        var entity = new Product(id, catalogId, name, description);
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
