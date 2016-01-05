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
    public class ProductMapper : BaseMapper<Product>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected override Product GetEntityFromReader(DataTableReader reader)
        {
            if (reader == null) return null;
            try
            {
                if (reader.Read())
                {
                    var id = (int)reader.GetValue(0);

                    var catalogId = 0;
                    var type = reader.GetValue(1).GetType();
                    if (type.Name != "DBNull")
                    {
                        catalogId = (int)reader.GetValue(1);
                    }
                    var name = reader.GetValue(2).ToString();

                    return new Product(id, catalogId, name);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
            return null;
        }
    }
}
