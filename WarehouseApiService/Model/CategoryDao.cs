using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseApiService.Model
{
    public class CategoryDao : ModelDao
    {
        private WarehouseDBDataContext context;
        public CategoryDao()
        {
            context = new WarehouseDBDataContext();
        }      
        
        public object getAll()
        {
            return context.Categories.ToList();
        }

        public object getDetail(object code)
        {
            return context.Categories.FirstOrDefault(x => x.CateCode == (int)code);
        }

        public object add(object obj)
        {
            context.Categories.InsertOnSubmit( (Category) obj);
            context.SubmitChanges();
            return (Category)obj;
        }

        public object edit(object obj)
        {
            Category cate = obj as Category;
            var check = context.Categories.FirstOrDefault(x => x.CateCode == cate.CateCode);
            if (check != null)
            {
                check.CateName = cate.CateName;
                check.CateImage = cate.CateImage;
                context.SubmitChanges();
                return check;
            }
            else
            {
                return "Không có category để sửa";
            }
        }

        public object delete(object obj)
        {
            Category cate = obj as Category;
            var check = context.Products.Where(x => x.CateCode == cate.CateCode).Count();
            if(check == 0)
            {
                context.Categories.DeleteOnSubmit(context.Categories.FirstOrDefault(x=>x.CateCode == cate.CateCode));
                context.SubmitChanges();
                return true;
            }
            else
            {
                return "Không thể xoá category này vì có sản phẩm thuộc category này!!";
            }
        }
    }
}