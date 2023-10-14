using FluentValidationApp.Web.Models;
using System.Collections.Generic;
using System;

namespace FluentValidationApp.Web.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Eposta { get; set; }
        public int Yas { get; set; }
        public string FullName { get; set; }
        public string CVCNumber { get; set; }
        public string Number { get; set; }
        public DateTime ValidDate { get; set; }
        //public string CreditCardNumber { get; set; }
        //Prop Adı : ClassName+PropName 
        //Örnek: CreditCardNumber --> CreditCard sınıfındaki Number propu bu şekilde temsil edilecek
        //AutoMapper bunu otomatik olarak eşlicek
        //public DateTime CreditCardValidDate { get; set; }

    }
}
