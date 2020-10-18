using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseApiService.Model
{
    interface ModelDao
    {
        object getAll();
        object getDetail(object code);
        object add(object obj);
        object edit(object obj);
        object delete(object obj);
    }
}
