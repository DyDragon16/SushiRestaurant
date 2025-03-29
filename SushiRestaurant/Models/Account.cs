using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSysCore.Models
{
    public partial class Account
    {
        public Account()
        {
            Histories = new HashSet<History>();
            Orders = new HashSet<Order>();
            Reservations = new HashSet<Reservation>();
        }

        public int UserId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? UserName { get; set; }

        [Required]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Password must contain uppcase, lowercase, numbers, symbols, min 8 chars")]
        public string? Password { get; set; }
        public int? RoleId { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Invalid Email")]

        public string? Email { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
