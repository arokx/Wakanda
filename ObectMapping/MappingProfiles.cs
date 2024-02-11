using AutoMapper;
using Domain.Entities;
using DTO;

namespace ObectMapping
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Customer, CustomerDto>();
                  //.ForMember(d => d.ServiceCategoryId, o => o.MapFrom(s => s.ServiceCategoryId))
                  //.ForMember(d => d.ServiceCategoryName, o => o.MapFrom(s => s.ServiceCategory.CategoryName))
                  //.ForMember(d => d.TokenId, o => o.MapFrom(s => s.Token.Id));
        }
    }
}
