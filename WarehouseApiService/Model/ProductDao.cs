using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseApiService.Model
{
    public class ProductDao : ModelDao
    {
        private WarehouseDBDataContext context;
        public ProductDao()
        {
            context = new WarehouseDBDataContext();
        }
        public object viewStructProduct()
        {
            return context.Products.ToList().ElementAt(1);
        }
             
        public object getAll()
        {
            return context.sp_get_all_product();
        }

        public object getDetail(object code)
        {
            return context.sp_get_detail_product((string)code);
        }

        public object add(object obj)
        {
            Product prd = (Product)obj;
            Product prdCheck = context.Products.FirstOrDefault(x => x.PrdCode == prd.PrdCode);
            if (prdCheck == null)
            {
                context.Products.InsertOnSubmit(prd);
                context.SubmitChanges();
                prd = context.Products.FirstOrDefault(x => x.PrdCode == prd.PrdCode);
                return prd;
            }
            else
            {
                return "Lỗi, Mã sản phẩm đã tồn tại, kiểm tra lại mã sản phẩm!!. PrdCode Data type is nchar(5)";
            }
        }

        public object edit(object obj)
        {
            Product prd = (Product)obj;
            Product prdCheck = context.Products.FirstOrDefault(x => x.PrdCode == prd.PrdCode);
            if (prdCheck != null)
            {
                prdCheck.PrdName = prd.PrdName;
                prdCheck.BrandCode = prd.BrandCode;
                prdCheck.UnitCode = prd.UnitCode;
                prdCheck.CateCode = prd.CateCode;
                prd.ShortDesc = prd.ShortDesc;
                prd.FullDesc = prd.FullDesc;
                prd.Image = prd.Image;

                context.SubmitChanges();
                prd = context.Products.FirstOrDefault(x => x.PrdCode == prd.PrdCode);
                return prd;
            }
            else
            {
                return "Lỗi, Không có sản phẩm để edit!!";
            }
        }

        public object delete(object obj)
        {
            throw new NotImplementedException();
        }
        public object getByCategoryCode(int code)
        {
            return context.sp_get_all_product_by_category(code);
        }
        public object getByBrandCode(int code)
        {
            return context.sp_get_all_product_by_brand(code);
        }
    }
}