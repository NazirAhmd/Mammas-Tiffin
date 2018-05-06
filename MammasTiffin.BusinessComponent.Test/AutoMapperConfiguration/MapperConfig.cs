using AutoMapper;
using MammasTiffin.BusinessComponent.BusinessModels;
using MammasTiffin.Entities.EntityFramework;

namespace MammasTiffin.Common.AutoMapperConfiguration
{
    public static class MapperConfig
    {
        public static void RegisterAutoMapperConfigurations()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<ItemBM, Item>();
                config.CreateMap<ItemImageBM, ItemImage>();
                config.CreateMap<Item, MenuDetailBM>().ForMember(dest => dest.ImageData, opt => opt.MapFrom(src => src.ItemImage.ImageData));
            });
        }
    }
}
