using System;
using System.Collections.Generic;

namespace ECommerceSysCore.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int CartId { get; set; }
        public int? TableId { get; set; }
        public int? UserId { get; set; }
        public int? CreateDate { get; set; }

        public virtual Table? Table { get; set; }
        public virtual Account? User { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
