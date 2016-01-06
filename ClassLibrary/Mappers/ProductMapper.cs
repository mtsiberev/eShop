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
            throw new NotImplementedException();
        }
    }
}
