using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Helpers;
using NLog;

namespace ClassLibrary.Mappers
{
    public class OrderMapper : IMapper<Order>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<Order> GetEntityList(string queryString)
        {
            var resultList = new List<Order>();
            using (var table = DataBaseHelper.GetExecutionResult(queryString))
            {
                if (table.Rows.Count == 0) return null;

                try
                {
                    var orderItemsList = new List<OrderItem>();

                    var userId = 0;
                    var orderId = 0;
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        userId = Convert.ToInt32(table.Rows[i]["UserId"]);
                        orderId = Convert.ToInt32(table.Rows[i]["Id"]);

                        var productId = 0;
                        var qty = 0;
                        var name = "";
                   
                        var type = table.Rows[i]["ProductId"].GetType();
                        if (type.Name == "DBNull")
                        {
                            break;
                        }
                        
                        productId = Convert.ToInt32(table.Rows[i]["ProductId"]);
                        qty = Convert.ToInt32(table.Rows[i]["Qty"]);
                        name = table.Rows[i]["Name"].ToString();
                        
                        var entity = new OrderItem(orderId, productId, qty, name);
                        orderItemsList.Add(entity);
                    }
                    resultList.Add(new Order(orderId, userId, orderItemsList));
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return null;
                }
            }
            return resultList;
        }
    }
}
