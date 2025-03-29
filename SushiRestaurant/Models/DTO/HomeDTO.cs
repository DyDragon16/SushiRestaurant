using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerceSysCore.Models.DTO
{
    public class HomeDTO
    {
        public List<Product> NewestProducts { get; set; }
        public List<Product> BestSellerProducts { get; set; }
        public Reservation Reservation { get; set; }
        public List<SelectListItem> Hours { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "09:00:00", Text = "09:00" },
            new SelectListItem { Value = "10:00:00", Text = "10:00" },
            new SelectListItem { Value = "11:00:00", Text = "11:00" },
            new SelectListItem { Value = "12:00:00", Text = "12:00" },
            new SelectListItem { Value = "13:00:00", Text = "13:00" },
            new SelectListItem { Value = "14:00:00", Text = "14:00" },
            new SelectListItem { Value = "15:00:00", Text = "15:00" },
            new SelectListItem { Value = "16:00:00", Text = "16:00" },
            new SelectListItem { Value = "17:00:00", Text = "17:00" },
            new SelectListItem { Value = "18:00:00", Text = "18:00" },
            new SelectListItem { Value = "19:00:00", Text = "19:00" },
            new SelectListItem { Value = "20:00:00", Text = "20:00" },
            new SelectListItem { Value = "21:00:00", Text = "21:00" },
            new SelectListItem { Value = "22:00:00", Text = "22:00" }
        };
        public List<SelectListItem> Location { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Indoor Seating", Text = "Indoor Seating" },
            new SelectListItem { Value = "Outdoor Seating", Text = "Outdoor Seating" },
            new SelectListItem { Value = "Specialized Seating", Text = "Specialized Seating" }
        };
        
    }
}
