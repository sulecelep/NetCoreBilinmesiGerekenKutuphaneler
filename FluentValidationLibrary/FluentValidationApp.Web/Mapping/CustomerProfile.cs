﻿using AutoMapper;
using FluentValidationApp.Web.DTOs;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreditCard,CustomerDto>(); //IncludeMembers!ları da bu şekilde destination olarak maplemeliyiz
            CreateMap<Customer, CustomerDto>().IncludeMembers(x=>x.CreditCard)
                .ForMember(dest=>dest.Isim,opt=>opt.MapFrom(x=>x.Name))
                .ForMember(dest=>dest.Eposta,opt=>opt.MapFrom(x=>x.Email))
                .ForMember(dest=>dest.Yas,opt=>opt.MapFrom(x=>x.Age))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(x => x.FullName2()));

            //.ForMember(dest=>dest.CVCNumber,opt=>opt.MapFrom(x=>x.CreditCard.CVCNumber))
        }
    }
}
