using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WarehouseApiService.Interface;
using WarehouseApiService.Model;
using WarehouseApiService.Response;

namespace WarehouseApiService.Controller
{
    public class CategoryController : BaseController, BaseApi
    {
     

        [HttpGet]
        public object getStructObject()
        {
            Category cate = new Category();
            cate.CateCode = 0;
            cate.CateName = "";
            return cate;
        }
        [HttpPost]
        public object modifierData([FromBody] JObject body, string funName)
        {
            switch (funName)
            {
                case "ADD":
                    {
                        return addFuntion(body);
                        break;
                    }
                case "EDIT":
                    {
                        return editFuntion(body);
                        break;
                    }
                case "DELETE":
                    {
                        return deleteFuntion(body);
                        break;
                    }
            }
            return funNameNoneResponse(funName);
        }
        public object addFuntion(JObject body)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = " Add new Category";
            try
            {
                Category cate = JsonConvert.DeserializeObject<Category>(body.ToString());
                var result = new CategoryDao().add(cate);
                response.returnData = result;
                response.returnMessage = " Thêm mới thành công!";
                response.returnCode = true;
            }
            catch(Exception ex)
            {
                response.returnCode = false;
                response.returnMessage = ex.Message;
            }
            return response;
        }

        public object deleteFuntion(JObject body)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = " Delete Category";
            try
            {
                Category cate = JsonConvert.DeserializeObject<Category>(body.ToString());
                var result = new CategoryDao().delete(cate);
                if(result is string)
                {
                    response.returnCode = false;
                    response.returnMessage = result.ToString();
                }
                else
                {
                    response.returnCode = true;
                    response.returnMessage = "Xóa thành công";
                }
            }
            catch (Exception ex)
            {
                response.returnCode = false;
                response.returnMessage = ex.Message;
            }
            return response;
        }

        public object editFuntion(JObject body)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = "Edit Category";
            try
            {
                Category cate = JsonConvert.DeserializeObject<Category>(body.ToString());
                var result = new CategoryDao().edit(cate);
                if(result is string)
                {
                    response.returnMessage = result.ToString();
                    response.returnCode = false;
                }
                else
                {
                    response.returnData = result;
                    response.returnMessage = "Chỉnh sửa thành công!";
                    response.returnCode = true;
                }
            }
            catch (Exception ex)
            {
                response.returnCode = false;
                response.returnMessage = ex.Message;
            }
            return response;
        }

        [HttpPost]
        public object getAll()
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = "List of all Category";
            try
            {
                response.returnCode = true;
                response.returnData = new CategoryDao().getAll();
            }
            catch (Exception ex)
            {
                response.returnCode = false;
                response.returnMessage = ex.Message;
            }
            return response;
        }
        [HttpPost]
        public object getDetail(object code)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = "Detail of Category";
            try
            {
                response.returnCode = true;
                response.returnData = new CategoryDao().getDetail(code);
            }
            catch (Exception ex)
            {
                response.returnCode = false;
                response.returnMessage = ex.Message;
            }
            return response;
        }
    }
}
