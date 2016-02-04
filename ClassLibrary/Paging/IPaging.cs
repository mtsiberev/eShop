using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Paging
{
    public interface IPaging<T>
    {
        List<T> GetEntitiesForOnePage(int pageNum, int pageSize, int parentId);
        int GetCountOfEntities(int parentId);
    }
}
