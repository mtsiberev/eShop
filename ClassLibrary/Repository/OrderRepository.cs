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
        private readonly IMapper<Order> m_orderMapper = new OrderMapper();

        private const string c_ordersDatabaseName = "Orders";
        private const string c_orderItemsDatabaseName = "OrderItems";

        public void Add(Order entity)
        {
            var queryString = String.Format("INSERT INTO {0} (UserId) VALUES ({1});",
                c_ordersDatabaseName,
                entity.UserId
        );
            DataBaseHelper.ExecuteCommand(queryString);
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
           var queryString = String.Format("SELECT * FROM {0} INNER JOIN {1} ON {0}.OrderId = {1}.Id WHERE ({1}.UserId = {2});",
                c_orderItemsDatabaseName,
                c_ordersDatabaseName,
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
            var queryString = String.Format("SELECT * FROM {0} INNER JOIN {1} ON {0}.OrderId = {1}.Id;",
          c_orderItemsDatabaseName,
          c_ordersDatabaseName);
            try
            {
                return  m_orderMapper.GetEntityList(queryString);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }
    }
}
