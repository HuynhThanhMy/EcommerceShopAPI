using AutoMapper;
using EcommerceWebAPI.Data;
using EcommerceWebAPI.Models;

namespace EcommerceWebAPI.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
