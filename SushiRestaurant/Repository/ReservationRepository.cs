using ECommerceSysCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceSysCore.Repository
{
    public class ReservationRepository
    {
        private readonly SushiRestaurantContext context;
        public ReservationRepository(SushiRestaurantContext context)
        {
            this.context = context;
        }
        public List<Reservation> getAll()
        {
            return context.Reservations.ToList();
        }
        public List<Reservation> getAllWithoutCancel()
        {
            return context.Reservations.Where(p => p.Status == true).ToList();
        }
        public Reservation getById(int id)
        {
            return context.Reservations.Where(p => p.ReservationId == id).FirstOrDefault();
        }
    }
}
