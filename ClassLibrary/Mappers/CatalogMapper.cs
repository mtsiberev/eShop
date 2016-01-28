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
    public class CatalogMapper : BaseMapper<Catalog>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override List<Catalog> GetEntityList(string queryString)
        {
            var resultList = new List<Catalog>();
            using (var table = DataBaseHelper.GetExecutionResult(queryString))
            {
                if (table.Rows.Count == 0) return resultList;
                try
                {
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var id = Convert.ToInt32(table.Rows[i]["Id"]);
                        var name = table.Rows[i]["Name"].ToString();
                        var entity = new Catalog(id, name);
                        resultList.Add(entity);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return resultList;
                }
            }
            return resultList;
        }

    }
}
