using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseApiService.Response
{
    public class BaseResponse
    {
        public String returnDescription { get; set; }
        public String returnMessage { get; set; }
        public Boolean returnCode { get; set; }
        public Object returnData { get; set; }
    }
}