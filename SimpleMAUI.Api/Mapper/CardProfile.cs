using AutoMapper;
using SimpleMAUI.BLL.DTOs.In;
using SimpleMAUI.BLL.DTOs.Out;
using SimpleMAUI.BLL.Models;

namespace SimpleMAUI.Api.Mapper
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardInDto, Card>();
            CreateMap<Card, CardOutDto>();
        }
    }
}
