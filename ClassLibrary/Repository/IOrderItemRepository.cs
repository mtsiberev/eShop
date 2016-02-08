using System;
using System.Collections.Generic;
using ClassLibrary.BusinessObjects;

namespace ClassLibrary.Repository
{
    public interface IOrderItemRepository 
    {
        void Add(OrderItem entity);
        void Update(OrderItem entity);
        void DeleteByCompoundId(int orderId, int productId);
        OrderItem GetByCompoundId(int orderId, int productId);
        List<OrderItem> GetAll();
        List<OrderItem> GetAllByFirstKeyId(int id);
        List<OrderItem> GetAllBySecondKeyId(int id);
    }
}
