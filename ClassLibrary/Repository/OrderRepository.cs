using System;
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
    public class OrderRepository : IRepository<Order>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly BaseMapper<Order> m_orderMapper = new OrderMapper();

        private const string c_ordersDatabaseName = "Orders";
        private const string c_orderItemsDatabaseName = "OrderItems";
        private const string c_productsDatabaseName = "Products";
        
        public int Add(Order entity)
        {
            var queryString = String.Format("INSERT INTO {0} (UserId) VALUES ({1});",
                c_ordersDatabaseName,
                entity.UserId
        );
     
            return m_orderMapper.GetLastCreatedId(queryString);
        }

        public void Delete(int id)
        {
            var queryString = String.Format("DELETE FROM {0} WHERE Id = {1};",
             c_ordersDatabaseName,
             id);
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public Order GetById(int id)
        {
            var queryString =
            String.Format("SELECT * FROM {0} LEFT JOIN {1} ON {0}.Id = {1}.OrderId LEFT JOIN {2} ON {1}.ProductId = {2}.Id WHERE UserId = {3};",
            c_ordersDatabaseName,
            c_orderItemsDatabaseName,
            c_productsDatabaseName,
            id);

            try
            {
                var order = m_orderMapper.GetEntityList(queryString).First();
                return order;
            }

            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            var queryString =
                String.Format("SELECT * FROM {0} LEFT JOIN {1} ON {0}.Id = {1}.OrderId LEFT JOIN {2} ON {1}.ProductId = {2}.Id;",
                c_ordersDatabaseName,
                c_orderItemsDatabaseName,
                c_productsDatabaseName);
            try
            {
                return m_orderMapper.GetEntityList(queryString);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public List<Order> GetEntitiesForOnePage(int pageNum, int pageSize, int parentId)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfEntities(int parentId)
        {
            throw new NotImplementedException();
        }
    }
}
