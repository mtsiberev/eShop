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
    public class OrderItemMapper : BaseMapper<OrderItem>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override List<OrderItem> GetEntityList(string queryString)
        {
            var resultList = new List<OrderItem>();
            using (var table = DataBaseHelper.GetExecutionResult(queryString))
            {
                if (table.Rows.Count == 0) return resultList;
                try
                {
                    for (var i = 0; i < table.Rows.Count; i++)
                    {
                        var orderId = Convert.ToInt32(table.Rows[i]["OrderId"]);
                        var productId = Convert.ToInt32(table.Rows[i]["ProductId"]);
                        var qty = Convert.ToInt32(table.Rows[i]["Qty"]);
                        var name = table.Rows[i]["Name"].ToString();

                        var entity = new OrderItem(orderId, productId, qty, name);
                        resultList.Add(entity);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    return resultList;
                }
            }
            return resultList;
        }
    }
}
