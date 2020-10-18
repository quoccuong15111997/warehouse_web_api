using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WarehouseApiService.Interface
{
    interface BaseApi
    {     
        object getStructObject();
        object getAll();
        object getDetail(object code);      
        object modifierData([FromBody] JObject body, string funName);
        object addFuntion(JObject body);
        object editFuntion(JObject body);
        object deleteFuntion(JObject body);

    }
}
