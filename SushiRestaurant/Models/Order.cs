using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSysCore.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(50)]
        public string? CustomerName { get; set; }
        public double? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(0)\d{9}$", ErrorMessage = "Not a valid phone number: 0123123123")]
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Note { get; set; }
        public string? Email { get; set; }
        public string? TypeOrder { get; set; }
        public string? PaymentMethod { get; set; }
        public bool? Status { get; set; }
        public int? HistoryId { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TableId { get; set; }

        public string? PaymentProcess {  get; set; }

        public virtual History? History { get; set; }
        public virtual Table? Table { get; set; }
        public virtual Account? User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
