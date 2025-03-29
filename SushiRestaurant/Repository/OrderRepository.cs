using ECommerceSysCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSysCore.Repository
{
    public class OrderRepository
    {
        private readonly SushiRestaurantContext context;
        public OrderRepository(SushiRestaurantContext context)
        {
            this.context = context;
        }
        public List<Order> getAll()
        {
            return context.Orders.ToList();
        }

        public Order getById(int id)
        {
            return context.Orders.Where(p => p.OrderId == id).FirstOrDefault();
        }
    }
}
