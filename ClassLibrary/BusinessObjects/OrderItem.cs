using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.BusinessObjects
{
    public class OrderItem
    {
        public OrderItem(int orderId, int productId, int qty, string productName)
        {
            OrderId = orderId;
            ProductId = productId;
            Qty = qty;
            ProductName = productName;
        }

        public int OrderId { get; private set; }
        public int ProductId { get; private set; }
        public int Qty { get; set; }
        public string ProductName { get; set; }
    }
}
