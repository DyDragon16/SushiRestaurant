using ECommerceSysCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSysCore.Repository
{
    public class ProductRepository
    {
        private readonly SushiRestaurantContext context;
        public ProductRepository(SushiRestaurantContext context)
        {
            this.context = context;
        }

        public List<Product> getTop6BestSeller()
        {
            return context.Products.FromSqlRaw("with R as(select p.ProductID, sum(o.Quantity) SL from Product p, OrderDetail o where p.ProductID = o.ProductID group by p.ProductID) select top 6 p.* from R, Product p where R.ProductID = p.ProductID and p.Status = 1 order by R.SL desc").ToList();
        }

        public List<Product> getTop6Newest()
        {
            return context.Products.Include(c => c.Category).Where(p => p.Status == true).OrderByDescending(p => p.ProductId).Take(6).ToList();
        }

        public List<Product> getAllByCategoryAndName(int categoryId, string txtSearch)
        {
            return context.Products.Include(c => c.Category).Where(p => p.Status == true && (categoryId == 0 || p.CategoryId == categoryId) && (txtSearch.Equals("") || p.ProductName.Contains(txtSearch))).ToList();
        }

        public List<Product> getAllByCategoryId(int categoryId)
        {
            return context.Products.Include(c => c.Category).Where(p => p.Status == true && (categoryId == 0 || p.CategoryId == categoryId)).ToList();
        }

        public List<Product> getAll()
        {
            return context.Products.Include(c => c.Category).Where(p => p.Status == true).ToList();
        }

        public Product getById(int id)
        {
            return context.Products.Include(c => c.Category).Where(p => p.ProductId == id).FirstOrDefault();
        }

    }
}
