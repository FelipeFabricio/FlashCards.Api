using AutoMapper;
using FlashCards.Api.ViewModels;
using FlashCards.Business.Models;

namespace FlashCards.Api.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Card, CardViewModel>().ReverseMap();
            CreateMap<Deck, DeckViewModel>().ReverseMap();
            CreateMap<Memorization, MemorizationViewModel>().ReverseMap();
        }
    }
}
