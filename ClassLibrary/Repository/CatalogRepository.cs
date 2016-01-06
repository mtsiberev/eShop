using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Mappers;

namespace ClassLibrary.Repository
{
    public class CatalogRepository : IRepository<Catalog>
    {
        private const string c_usersDatabaseName = "Catalogs";
        private readonly IMapper<Catalog> m_catalogMapper = new CatalogMapper();
        
        public void Add(Catalog entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Catalog entity)
        {
            throw new NotImplementedException();
        }

        public List<Catalog> GetAll()
        {
            throw new NotImplementedException();
        }

        public Catalog GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
