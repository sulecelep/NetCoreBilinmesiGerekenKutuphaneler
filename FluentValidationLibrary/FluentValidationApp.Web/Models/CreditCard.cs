using System;

namespace FluentValidationApp.Web.Models
{
    public class CreditCard
    {
        public string Number { get; set; }
        public string CVCNumber { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
