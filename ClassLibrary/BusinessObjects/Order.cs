using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClassLibrary.BusinessObjects
{
    public class Order
    {
        public Order(int id, int userId, List<OrderItem> itemsList)
        {
            Id = id;
            UserId = userId;
            OrderItemsList = itemsList;
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public List<OrderItem> OrderItemsList { get; set; }
    }
}
