using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.BusinessObjects
{
    public class User
    {
        public User(int id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
