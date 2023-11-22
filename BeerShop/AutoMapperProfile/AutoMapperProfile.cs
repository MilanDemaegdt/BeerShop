using AutoMapper;
using BeerShop.Areas.Admin.ViewModels;
using BeerShop.ViewModels;
using BeerShopDB.Models.Entities;

namespace BeerShop.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Beer, BeerVM>();

           CreateMap<Beer, BeerVM>().ForMember(dest => dest.BrouwerNaam,
           opts => opts.MapFrom(
               src => src.BrouwernrNavigation.Naam

           ))
                           .ForMember(dest => dest.SoortNaam,
               opts => opts.MapFrom(
                   src => src.SoortnrNavigation.Soortnaam
               ));


            CreateMap<Beer, BeerAdminVM>().ForMember(dest => dest.BrouwerNaam,
           opts => opts.MapFrom(
               src => src.BrouwernrNavigation.Naam

           ))
                           .ForMember(dest => dest.SoortNaam,
               opts => opts.MapFrom(
                   src => src.SoortnrNavigation.Soortnaam
               ));




            //Mapper
            CreateMap<CreateBeerVM, Beer>();
            CreateMap<Beer, CreateBeerVM>();



        }


        


    }
}
