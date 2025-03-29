using System;
using System.Collections.Generic;

namespace ECommerceSysCore.Models
{
    public partial class Product
    {
        public Product()
        {
            Histories = new HashSet<History>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? ShortDes { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } = "noimage.jpg";
        public int CategoryId { get; set; }
        public bool? Status { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
