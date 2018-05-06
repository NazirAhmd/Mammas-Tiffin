using AutoMapper;
using MammasTiffin.BusinessComponent.BusinessModels;
using MammasTiffin.Entities.EntityFramework;
using MammasTiffin.Web.ViewModels.Admin;
using MammasTiffin.Web.ViewModels.MammasTiffin;

namespace MammasTiffin.Web.App_Start
{
    public static class MapperConfig
    {
        public static void RegisterAutoMapperConfigurations()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<ItemDetailVM, ItemBM>();
                config.CreateMap<ItemBM, Item>();
                config.CreateMap<ItemImageBM, ItemImage>();
                config.CreateMap<Item, MenuDetailBM>().ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => src.ItemImage.ImageData));
                config.CreateMap<MenuDetailBM, MenuDetail>();
            });
        }
    }
}