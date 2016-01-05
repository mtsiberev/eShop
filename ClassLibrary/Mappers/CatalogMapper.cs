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

        protected override Catalog GetEntityFromReader(DataTableReader reader)
        {
            if (reader == null) return null;
            try
            {
                if (reader.Read())
                {
                    var id = (int)reader.GetValue(0);
                    var name = reader.GetValue(1).ToString();

                    return new Catalog(id, name);
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
