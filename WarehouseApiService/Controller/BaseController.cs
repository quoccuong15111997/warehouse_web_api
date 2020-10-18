using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarehouseApiService.Interface;
using WarehouseApiService.Response;

namespace WarehouseApiService.Controller
{
    public abstract class BaseController : ApiController
    {
        protected object funNameNoneResponse(string funName)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = funName;
            response.returnMessage = "Không có mục xử lý cho funName = " + funName;
            response.returnCode = false;
            return response;
        }
    }
}
