using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Mappers
{
    interface IMapper <T> where T : class
    {
        List<T> GetEntityList(string queryString);
    }
}
