using System;
using System.Collections.Generic;

namespace ECommerceSysCore.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Image { get; set; } = "noimage.jpg";

        public virtual ICollection<Product> Products { get; set; }
    }
}
