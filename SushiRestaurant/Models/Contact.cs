using System;
using System.Collections.Generic;

namespace ECommerceSysCore.Models
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string? CustomerName { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        public DateTime? CreateMessageDate { get; set; }
        public string? ResponseMessage { get; set; }
        public DateTime? ResponseMessageDate { get; set; }
    }
}
