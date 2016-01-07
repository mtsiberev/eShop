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
    public class UserRepository : IRepository<User>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string c_usersDatabaseName = "Users";
        private readonly IMapper<User> m_userMapper = new UserMapper();
        
        public void Add(User entity)
        {
            var queryString = String.Format("INSERT INTO {0} (Name, Address) VALUES ('{1}', '{2}');",
                c_usersDatabaseName, 
                entity.Name, 
                entity.Address);
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public void Delete(int id)
        {
            var queryString = String.Format("DELETE FROM {0} WHERE Id = {1};",
           c_usersDatabaseName, 
           id);
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public void Update(User entity)
        {
            var queryString = String.Format("UPDATE {0} SET Name = '{1}', Address = '{2}' WHERE Id = {3}",
                c_usersDatabaseName,
                entity.Name,
                entity.Address,
                entity.Id);
            DataBaseHelper.ExecuteCommand(queryString);
        }

        public List<User> GetAll()
        {
            var queryString = String.Format("SELECT * FROM {0};", c_usersDatabaseName);
            return m_userMapper.GetEntityList(queryString);
        }

        public User GetById(int id)
        {
            var queryString = String.Format("SELECT TOP 1 * FROM {0} WHERE Id = {1};", c_usersDatabaseName, id);

            try
            {
                var user = m_userMapper.GetEntityList(queryString).First();
                return user;
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                return null;
            }
            
        }
    }
}
