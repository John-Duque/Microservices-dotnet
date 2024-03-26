using AutoMapper;
using ItemService.Dtos;
using ItemService.Models;

namespace ItemService.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Restaurante, RestauranteReadDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdExterno))
            .ReverseMap();
            CreateMap<Item, ItemCreateDto>().ReverseMap();
        }
    }
}