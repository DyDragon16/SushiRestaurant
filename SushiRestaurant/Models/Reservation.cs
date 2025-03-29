using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerceSysCore.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? UserId { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(50)]
        public string? CustomerName { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please enter Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(0)\d{9}$", ErrorMessage = "Not a valid phone number: 0123123123")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Please enter Number of Guest")]
        public int? NumOfGuests { get; set; }
        [Required(ErrorMessage = "Please enter Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReservationDate { get; set; } = DateTime.Today;
        [Required(ErrorMessage = "Please enter Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Time { get; set; }
        public string? Message { get; set; }

        public bool? Status { get; set; }
		[Required(ErrorMessage = "Please enter Location")]
		public string? Location { get; set; }
		public virtual Account? User { get; set; }
    }
}
