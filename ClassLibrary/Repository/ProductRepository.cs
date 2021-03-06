﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Helpers;
using ClassLibrary.IoC;
using ClassLibrary.Mappers;
using ClassLibrary.Paging;
using NLog;


namespace ClassLibrary.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string c_productsDatabaseName = "Products";

        private readonly BaseMapper<Product> m_productMapper = new ProductMapper();

        public int GetLastCreatedId(string queryString)
        {
            var resultId = 0;
            using (var table = DataBaseHelper.GetExecutionResult(queryString))
            {
                if (table.Rows.Count == 0) return resultId;
                try
                {
                    var type = table.Rows[0]["Id"].GetType();
                    if (type.Name != "DBNull")
                    {
                        resultId = Convert.ToInt32(table.Rows[0]["Id"]);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }
            }
            return resultId;
        }
        
        public int Add(Product entity)
        {
            var queryString = "";

            if (entity.CatalogId == 0)
            {
                queryString = String.Format("INSERT INTO {0} (Name, Description) VALUES ('{1}', '{2}'); SELECT IDENT_CURRENT('{0}') AS Id;",
                    c_productsDatabaseName,
                    entity.Name,
                    entity.Description
                  );
            }
            else
            {
                queryString = String.Format("INSERT INTO {0} (Name, Description, CatalogId) VALUES ('{1}', '{2}', {3}); SELECT IDENT_CURRENT('{0}') AS Id;",
                    c_productsDatabaseName,
                    entity.Name,
                    entity.Description,
                    entity.CatalogId);
            }
            return m_productMapper.GetLastCreatedId(queryString);
        }

        public void Delete(int id)
        {
            var queryString = String.Format("DELETE FROM {0} WHERE Id = {1};",
                c_productsDatabaseName,
                id);
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public void Update(Product entity)
        {
            var queryString = "";

            if (entity.CatalogId == 0)
            {
                queryString = String.Format("UPDATE {0} SET Name = '{1}', Description = '{2}' WHERE Id = {3}",
                c_productsDatabaseName,
                entity.Name,
                entity.Description,
                entity.Id);
            }
            else
            {
                queryString = String.Format("UPDATE {0} SET CatalogId = '{1}', Name = '{2}', Description = '{3}' WHERE Id = {4}",
                   c_productsDatabaseName,
                   entity.CatalogId,
                   entity.Name,
                   entity.Description,
                   entity.Id);
            }

            DataBaseHelper.ExecuteCommand(queryString);
        }

        public List<Product> GetAll()
        {
            var queryString = String.Format("SELECT * FROM {0};", c_productsDatabaseName);
            return m_productMapper.GetEntityList(queryString);
        }

        public Product GetById(int id)
        {
            var queryString = String.Format("SELECT TOP 1 * FROM {0} WHERE Id = {1};", c_productsDatabaseName, id);

            try
            {
                var user = m_productMapper.GetEntityList(queryString).First();
                return user;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public List<Product> GetEntitiesForOnePage(int pageNum, int pageSize, int parentId)
        {
            var queryString = String.Format(
                "SELECT * FROM {0} " +
                "WHERE CatalogId = {1} " +
                "ORDER BY Name " +
                "OFFSET ({2} - 1) * {3} ROWS " +
                "FETCH NEXT {3} ROWS ONLY;",
                c_productsDatabaseName, parentId, pageNum, pageSize);

            return m_productMapper.GetEntityList(queryString);
        }

        public int GetCountOfEntities(int parentId)
        {
            var queryString = String.Format("SELECT * FROM {0} WHERE CatalogId = {1};", c_productsDatabaseName, parentId);
            return m_productMapper.GetEntityList(queryString).Count;
        }
    }
}
