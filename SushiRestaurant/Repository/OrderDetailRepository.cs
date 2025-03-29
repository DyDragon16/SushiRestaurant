using ECommerceSysCore.Models;

namespace ECommerceSysCore.Repository
{
    public class OrderDetailRepository
    {
        private readonly SushiRestaurantContext context;
        public OrderDetailRepository(SushiRestaurantContext context)
        {
            this.context = context;
        }

        public List<OrderDetail> getByOrderId(int id)
        {
            return context.OrderDetails.Where(p => p.OrderId == id).ToList();
        }
    }
}
