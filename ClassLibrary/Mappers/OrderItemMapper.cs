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
    public class OrderItemMapper : IMapper<OrderItem>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public List<OrderItem> GetEntityList(string queryString)
        {
            var resultList = new List<OrderItem>();
            using (var table = DataBaseHelper.GetExecutionResult(queryString))
            {
                if (table == null) return null;
                try
                {
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var orderId = Convert.ToInt32(table.Rows[i]["OrderId"]);
                        var productId = Convert.ToInt32(table.Rows[i]["ProductId"]);
                        var qty = Convert.ToInt32(table.Rows[i]["Qty"]);

                        var entity = new OrderItem(orderId, productId, qty);
                        resultList.Add(entity);
                    }
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
