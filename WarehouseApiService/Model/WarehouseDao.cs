using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseApiService.Model
{
    public class WarehouseDao
    {
        private WarehouseDBDataContext context;
        public WarehouseDao()
        {
            context = new WarehouseDBDataContext();
        }
    }
}