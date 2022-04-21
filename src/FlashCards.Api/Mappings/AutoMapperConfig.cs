using AutoMapper;
using FlashCards.Api.ViewModels;
using FlashCards.Business.Models;
using FlashCards.Business.Models.Cards;

namespace FlashCards.Api.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TextCard, TextCardViewModel>().ReverseMap();
            CreateMap<MultipleChoiceCard, MultipleChoiceCardViewModel>().ReverseMap();
            CreateMap<Deck, DeckViewModel>().ReverseMap();
            CreateMap<Memorization, MemorizationViewModel>().ReverseMap();
        }
    }
}
