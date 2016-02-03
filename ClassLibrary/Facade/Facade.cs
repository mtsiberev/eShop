using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Helpers;
using ClassLibrary.Repository;

namespace ClassLibrary.Facade
{
    public class Facade
    {
        private readonly IRepository<User> m_usersRepository;
        private readonly IRepository<Product> m_productsRepository;
        private readonly IRepository<Catalog> m_catalogsRepository;
        private readonly IRepository<Order> m_ordersRepository;
        private readonly IJunctionEntityRepository<OrderItem> m_orderItemsRepository;
        
        public Facade(
            IRepository<User> users,
            IRepository<Product> products,
            IRepository<Catalog> catalogs,
            IRepository<Order> orders,
            IJunctionEntityRepository<OrderItem> orderItems 
            )
        {
            m_usersRepository = users;
            m_productsRepository = products;
            m_catalogsRepository = catalogs;
            m_ordersRepository = orders;
            m_orderItemsRepository = orderItems;
        }
        //------------------Users methods
        public List<User> GetAllUsers()
        {
            return m_usersRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return m_usersRepository.GetById(id);
        }

        public void UpdateUser(User user)
        {
            m_usersRepository.Update(user);
        }
        
        public void DeleteUser(int id)
        {
            m_usersRepository.Delete(id);
        }
        //------------------Products methods
        public int AddProduct(Product product)
        {
          return m_productsRepository.Add(product);
        }
        
        public List<Product> GetAllProducts()
        {
            return m_productsRepository.GetAll();
        }
        
        public List<Product> GetProductsFromCatalog(int id)
        {
            var allCatalogs = m_productsRepository.GetAll();
            return allCatalogs.Count() != 0 ? allCatalogs.Where(x => x.CatalogId == id).ToList() : allCatalogs;
        }

        public Product GetProductById(int id)
        {
            return m_productsRepository.GetById(id);
        }
        
        public void UpdateProduct(Product product)
        {
            m_productsRepository.Update(product);
        }
      
        public void DeleteProduct(int id)
        {
            m_productsRepository.Delete(id);
        }
        //------------------Catalogs methods
        public void AddCatalog(Catalog catalog)
        {
            m_catalogsRepository.Add(catalog);
        }
        
        public List<Catalog> GetAllCatalogs()
        {
            return m_catalogsRepository.GetAll();
        }
        
        public List<Catalog> GetCatalogsForOnePage(int pageNum, int pageSize,  int parentId)
        {
            return m_catalogsRepository.GetEntitiesForOnePage(pageNum, pageSize, 0);
        }
        
        public Catalog GetCatalogById(int id)
        {
            return m_catalogsRepository.GetById(id);
        }

        public void UpdateCatalog(Catalog catalog)
        {
            m_catalogsRepository.Update(catalog);
        }

        public void DeleteCatalog(int id)
        {
            m_catalogsRepository.Delete(id);
        }
        //------------------Orders methods
        public List<Order> GetAllOrders()
        {
            return m_ordersRepository.GetAll();
        }

        public void AddOrder(Order order)
        {
            m_ordersRepository.Add(order);
        }

        public void DeleteOrder(int id)
        {
            m_ordersRepository.Delete(id);
        }

        public Order GetOrderByUserId(int id)
        {
            return m_ordersRepository.GetById(id);
        }

        //------------------OrderItems methods
        public void AddOrderItem(OrderItem orderItem)
        {
            m_orderItemsRepository.Add(orderItem);
        }

        public void DeleteOrderItem(OrderItem orderItem)
        {
            m_orderItemsRepository.DeleteByCompoundId(orderItem.OrderId, orderItem.ProductId);
        }

        public OrderItem GetOrderItem(int orderId, int productId)
        {
            return m_orderItemsRepository.GetByCompoundId(orderId, productId);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            m_orderItemsRepository.Update(orderItem);
        }
        
        public List<OrderItem> GetAllOrderItems()
        {
            return m_orderItemsRepository.GetAll();
        }

        public List<OrderItem> GetAllOrderItemsByOrderId(int id)
        {
            return m_orderItemsRepository.GetAllByFirstKeyId(id);
        }

        public List<OrderItem> GetAllOrderItemsByProductId(int id)
        {
            return m_orderItemsRepository.GetAllBySecondKeyId(id);
        }

    }
}
