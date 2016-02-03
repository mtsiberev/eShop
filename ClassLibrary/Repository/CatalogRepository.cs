using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Helpers;
using ClassLibrary.Mappers;
using ClassLibrary.Paging;
using NLog;

namespace ClassLibrary.Repository
{
    public class CatalogRepository : IRepository<Catalog>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string c_catalogsDatabaseName = "Catalogs";

        private readonly BaseMapper<Catalog> m_catalogMapper = new CatalogMapper();
        
        public int Add(Catalog entity)
        {
            var queryString = String.Format("INSERT INTO {0} (Name) VALUES ('{1}');",
             c_catalogsDatabaseName,
                entity.Name
              );
            //DataBaseHelper.ExecuteCommand(queryString);
            return m_catalogMapper.GetLastCreatedId(queryString);
        }

        public void Delete(int id)
        {
            var queryString = String.Format("DELETE FROM {0} WHERE Id = {1};",
                c_catalogsDatabaseName,
                id);
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public void Update(Catalog entity)
        {
            var queryString = String.Format("UPDATE {0} SET Name = '{1}' WHERE Id = {2}",
                c_catalogsDatabaseName,
                entity.Name,
                entity.Id);
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public List<Catalog> GetAll()
        {
            var queryString = String.Format("SELECT * FROM {0};", c_catalogsDatabaseName);
            return m_catalogMapper.GetEntityList(queryString);
        }

        public Catalog GetById(int id)
        {
            var queryString = String.Format("SELECT TOP 1 * FROM {0} WHERE Id = {1};", c_catalogsDatabaseName, id);

            try
            {
                var catalog = m_catalogMapper.GetEntityList(queryString).First();
                return catalog;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public List<Catalog> GetEntitiesForOnePage(int pageNum, int pageSize, int parentId)
        {
            var queryString = String.Format(
             "SELECT * FROM {0} " +
             "ORDER BY Name " +
             "OFFSET ({1} - 1) * {2} ROWS " +
             "FETCH NEXT {2} ROWS ONLY;",
             c_catalogsDatabaseName, pageNum, pageSize);

            return m_catalogMapper.GetEntityList(queryString);
        }
   
    }
}
