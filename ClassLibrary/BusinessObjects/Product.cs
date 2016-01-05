using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.BusinessObjects
{
    public class Product
    {
        public Product(int id, int catalogId, string name)
        {
            Id = id;
            CatalogId = catalogId;
            Name = name;
        }

        public int Id { get; private set; }
        public int CatalogId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
