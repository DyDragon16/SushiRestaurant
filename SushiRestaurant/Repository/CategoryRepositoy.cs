using ECommerceSysCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSysCore.Repository
{
    public class CategoryRepositoy
    {
        private readonly SushiRestaurantContext context;
        public CategoryRepositoy(SushiRestaurantContext context)
        {
            this.context = context;
        }
        public List<Category> getAll()
        {
            return context.Categories.ToList();
        }

		public List<Category> getAllWithProducts()
		{
			return context.Categories.Include(c => c.Products).Select(c => new Category
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Products = c.Products.Where(p => p.Status == true).ToList(),
                Image = c.Image,
            }).ToList();
		}

		public Category getById(int id)
        {
            return context.Categories.Where(p => p.CategoryId == id).FirstOrDefault();
        }
    }
}
