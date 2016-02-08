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
    public class OrderItemRepository : IOrderItemRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly BaseMapper<OrderItem> m_orderItemMapper = new OrderItemMapper();

        private const string c_ordersDatabaseName = "Orders";
        private const string c_orderItemsDatabaseName = "OrderItems";
        private const string c_productsDatabaseName = "Products";

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
            var queryString = String.Format("DELETE FROM {0} WHERE OrderId = {1} AND ProductId = {2};",
                c_orderItemsDatabaseName,
                id1,
                id2
            );
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public OrderItem GetByCompoundId(int id1, int id2)
        {
            var queryString =
                String.Format("SELECT * FROM {0} LEFT JOIN {1} ON {0}.ProductId = {1}.Id WHERE OrderId = {2} AND ProductId = {3};",
                c_orderItemsDatabaseName,
                c_productsDatabaseName,
                id1,
                id2);

            try
            {
                var orderItem = m_orderItemMapper.GetEntityList(queryString).First();
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

        public List<OrderItem> GetAll()
        {
            var queryString =
                String.Format("SELECT * FROM {0} LEFT JOIN {1} ON {0}.ProductId = {1}.Id;",
                c_orderItemsDatabaseName,
                c_productsDatabaseName);
            try
            {
                return m_orderItemMapper.GetEntityList(queryString);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public List<OrderItem> GetAllByFirstKeyId(int id)
        {
            var queryString =
                String.Format("SELECT * FROM {0} LEFT JOIN {1} ON {0}.ProductId = {1}.Id WHERE OrderId = {2};",
                c_orderItemsDatabaseName,
                c_productsDatabaseName,
                id);
            try
            {
                return m_orderItemMapper.GetEntityList(queryString);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }

        public List<OrderItem> GetAllBySecondKeyId(int id)
        {
            var queryString =
                String.Format("SELECT * FROM {0} LEFT JOIN {1} ON {0}.ProductId = {1}.Id WHERE ProductId = {2};",
                c_orderItemsDatabaseName,
                c_productsDatabaseName,
                id);
            try
            {
                return m_orderItemMapper.GetEntityList(queryString);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
        }
    }
}
