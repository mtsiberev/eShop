﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Helpers;
using ClassLibrary.Mappers;
using NLog;


namespace ClassLibrary.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string c_productsDatabaseName = "Products";

        private readonly IMapper<Product> m_productMapper = new ProductMapper();

        public void Add(Product entity)
        {
       //     NULL

            var queryString = String.Format("INSERT INTO {0} (Name, Description) VALUES ('{2}', '{3}');",
            //var queryString = String.Format("INSERT INTO {0} (CatalogId, Name, Description) VALUES ('{1}', '{2}', '{3}');",
                c_productsDatabaseName,
                entity.CatalogId,
                entity.Name,
                entity.Description);
            DataBaseHelper.ExecuteCommand(queryString);
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
            var queryString = String.Format("UPDATE {0} SET CatalogId = '{1}', Name = '{2}', Description = '{3}' WHERE Id = {4}",
                c_productsDatabaseName,
                entity.CatalogId,
                entity.Name,
                entity.Description,
                entity.Id);
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
    }
}