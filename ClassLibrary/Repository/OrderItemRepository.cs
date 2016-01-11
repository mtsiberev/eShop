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
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMapper<OrderItem> m_orderMapper = new OrderItemMapper();

        private const string c_ordersDatabaseName = "Orders";
        private const string c_orderItemsDatabaseName = "OrderItems";

        public void Add(OrderItem entity)
        {
            var queryString = String.Format("INSERT INTO {0} (OrderId, ProductId, Qty) VALUES ({1}, {2}, {3});",
                c_orderItemsDatabaseName,
                entity.OrderId,
                entity.ProductId,
                entity.Qty
                );
            DataBaseHelper.ExecuteCommand(queryString);
        }
        
        public void DeleteByCompoundId(int id1, int id2)
        {
            var queryString = String.Format("DELETE FROM {0} WHERE OrderId = {1} and ProductId = {2};",
                c_orderItemsDatabaseName,
                id1,
                id2
            );

            DataBaseHelper.ExecuteCommand(queryString);
        }

        public OrderItem GetByCompoundId(int id1, int id2)
        {
            var queryString = String.Format("SELECT * FROM {0} WHERE OrderId = {1} AND ProductId = {2};",
                c_orderItemsDatabaseName,
                id1,
                id2);
            try
            {
                var orderItem = m_orderMapper.GetEntityList(queryString).First();
                return orderItem;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public void Update(OrderItem entity)
        {
            var queryString = String.Format("UPDATE {0} SET Qty = '{1}' WHERE OrderId = {2} AND ProductId =  {3};",
                c_orderItemsDatabaseName,
                entity.Qty,
                entity.OrderId,
                entity.ProductId
                );
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public List<OrderItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderItem GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
