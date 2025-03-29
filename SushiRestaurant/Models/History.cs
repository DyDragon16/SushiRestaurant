using System;
using System.Collections.Generic;

namespace ECommerceSysCore.Models
{
    public partial class History
    {
        public History()
        {
            Orders = new HashSet<Order>();
        }

        public int HistoryId { get; set; }
        public int? OrdertId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public string? Action { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Account? User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
