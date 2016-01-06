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
    public class CatalogMapper : IMapper<Catalog>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<Catalog> GetEntityList(string queryString)
        {
            throw new NotImplementedException();
        }
    }
}
