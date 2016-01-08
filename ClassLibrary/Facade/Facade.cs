﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Repository;

namespace ClassLibrary.Facade
{
    public class Facade
    {
        private readonly IRepository<User> m_usersRepository;
        private readonly IRepository<Product> m_productsRepository;
        private readonly IRepository<Catalog> m_catalogsRepository;
        private readonly IRepository<Order> m_ordersRepository;
        
        public Facade(IRepository<User> users)
        {
            m_usersRepository = users;
            m_productsRepository = null;
            m_catalogsRepository = null;
            m_ordersRepository = null;
        }
        
        public Facade(IRepository<Product> products)
        {
            m_usersRepository = null;
            m_productsRepository = products;
            m_catalogsRepository = null;
            m_ordersRepository = null;
        }

        public Facade(
            IRepository<User> users,
            IRepository<Product> products,
            IRepository<Catalog> catalogs,
            IRepository<Order> orders
            )
        {
            m_usersRepository = users;
            m_productsRepository = products;
            m_catalogsRepository = catalogs;
            m_ordersRepository = orders;
        }

        public List<User> GetAllUsers()
        {
            return m_usersRepository.GetAll();
        }

        
        public void AddProduct(Product product)
        {
            m_productsRepository.Add(product);
        }
        
        public List<Product> GetAllProducts()
        {
            return m_productsRepository.GetAll();
        }
        
        public User GetUserById(int id)
        {
            return m_usersRepository.GetById(id);
        }
        
        public Product GetProductById(int id)
        {
            return m_productsRepository.GetById(id);
        }
        
        public void UpdateUser(User user)
        {
            m_usersRepository.Update(user);
        }
        
        public void UpdateProduct(Product product)
        {
            m_productsRepository.Update(product);
        }
        
        public void DeleteUser(int id)
        {
            m_usersRepository.Delete(id);
        }

        public void DeleteProduct(int id)
        {
            m_productsRepository.Delete(id);
        }

        public List<Catalog> GetAllCatalogs()
        {
            return m_catalogsRepository.GetAll();
        }
        
        public List<Order> GetAllOrders()
        {
            return m_ordersRepository.GetAll();
        }

    }
}