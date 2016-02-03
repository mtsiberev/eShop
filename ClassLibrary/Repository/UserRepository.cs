using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.BusinessObjects;
using ClassLibrary.Helpers;
using ClassLibrary.Mappers;
using ClassLibrary.Paging;
using NLog;

namespace ClassLibrary.Repository
{
    public class UserRepository : IRepository<User>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private const string c_usersDatabaseName = "Users";
        private readonly BaseMapper<User> m_userMapper = new UserMapper();
        
        public int Add(User entity)
        {
            var queryString = String.Format("INSERT INTO {0} (Name) VALUES ('{1}');",
                c_usersDatabaseName, 
                entity.Name);
            DataBaseHelper.ExecuteCommand(queryString);
            return m_userMapper.GetLastCreatedId(queryString);
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
            var queryString = String.Format("UPDATE {0} SET Name = '{1}' WHERE Id = {2}",
                c_usersDatabaseName,
                entity.Name,
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

        public List<User> GetEntitiesForOnePage(int pageNum, int pageSize, int parentId)
        {
            var queryString = String.Format(
             "SELECT * FROM {0} " +
             "ORDER BY Name " +
             "OFFSET ({1} - 1) * {2} ROWS " +
             "FETCH NEXT {2} ROWS ONLY;",
             c_usersDatabaseName, pageNum, pageSize);

            return m_userMapper.GetEntityList(queryString);
        }
      
    }
}
