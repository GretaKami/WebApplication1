using DataAccess.Context.Entities;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class CategoryExtension
    {
        public static CategoryModel ToModel(this Category category)
        {
            CategoryModel categoryModel = new CategoryModel
            {
                ID = category.Id,
                Title = category.Title,
                Subcategories = category.Subcategories.Select(s => new SubcategoryModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Products = s.Products.Select(p => p.ToModel()).ToList()

                }).ToList()

            };

            return categoryModel;
        }
    }
}
