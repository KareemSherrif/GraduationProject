﻿using AutoMapper;
using GraduationProject.Areas.Api.ViewModels;
using GraduationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject.Areas.Api.Profiles
{
    public class ProductProfile:Profile
    {

        public ProductProfile()
        {
            CreateMap<Product, SearchProductViewModel>()
                .ForMember(a => a.ProductId, a => a.MapFrom(a => a.Id))
                .ForMember(a => a.Name, a => a.MapFrom(a => a.Name))
                .ForMember(a => a.ModelID, a => a.MapFrom(a => a.ModelId))
                .ForMember(a => a.ModelName, a => a.MapFrom(a => a.Model.Name))
                .ForMember(a => a.BrandID, a => a.MapFrom(a => a.BrandId))
                .ForMember(a => a.BrandName, a => a.MapFrom(a => a.Brand.Name))
                .ForMember(a => a.Attributes, a => a.MapFrom(a => a.ProductAttributes));

               
        }
    }
}