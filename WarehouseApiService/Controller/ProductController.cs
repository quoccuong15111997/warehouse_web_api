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
    public class ProductController : BaseController, BaseApi
    {
        public object addFuntion(JObject body)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = "Add new product";
            try
            {
                Product prd = JsonConvert.DeserializeObject<Product>(body.ToString());
                var result = new ProductDao().add(prd);
                response.returnCode = result is Product;
                if (response.returnCode)
                {
                    response.returnData = result;
                    response.returnMessage = "Thêm sản phẩm thành công";
                }
                else
                {
                    response.returnMessage = result.ToString();
                }

            }
            catch (Exception ex)
            {
                response.returnCode = false;
                response.returnMessage = ex.Message;
            }

            return response;
        }

        public object deleteFuntion(JObject body)
        {
            return null;
        }

        public object editFuntion(JObject body)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = "Edit product";
            try
            {
                Product prd = JsonConvert.DeserializeObject<Product>(body.ToString());
                var result = new ProductDao().edit(prd);
                response.returnCode = result is Product;
                if (response.returnCode)
                {
                    response.returnData = result;
                    response.returnMessage = "Chỉnh sửa sản phẩm thành công";
                }
                else
                {
                    response.returnMessage = result.ToString();
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
            response.returnDescription = "List of all products";
            try
            {
                response.returnCode = true;
                response.returnData = new ProductDao().getAll();
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
            response.returnDescription = "Detail of products";
            try
            {
                response.returnCode = true;
                response.returnData = new ProductDao().getDetail(code);
            }
            catch (Exception ex)
            {
                response.returnCode = false;
                response.returnMessage = ex.Message;
            }
            return response;
        }

        [HttpGet]
        public object getStructObject()
        {
            Product prd = new Product();
            prd.PrdCode = "";
            prd.PrdName = "";
            prd.UnitCode = 0;
            prd.CateCode = 0;
            prd.BrandCode = 0;
            prd.Image = "";
            prd.ShortDesc = "";
            prd.FullDesc = "";
            prd.ColorCode = "";
            return prd;
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
        [HttpPost]
        public object getProductByCategory(int categoryCode)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = "List of products by category";
            try
            {
                response.returnCode = true;
                response.returnData = new ProductDao().getByCategoryCode(categoryCode);
            }
            catch (Exception ex)
            {
                response.returnCode = false;
                response.returnMessage = ex.Message;
            }
            return response;
        }
        [HttpPost]
        public object getProductByBrand(int brandCode)
        {
            BaseResponse response = new BaseResponse();
            response.returnDescription = "List of products by brand";
            try
            {
                response.returnCode = true;
                response.returnData = new ProductDao().getByBrandCode(brandCode);
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
