#nullable disable
using AutoMapper;
using FlashCards.Api.ViewModels;
using FlashCards.Business.Interfaces;
using FlashCards.Business.Models;
using FlashCards.Business.Models.Cards;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextCardsController : ControllerBase
    {
        private readonly ITextCardRepository _cardRepository;
        private readonly IMapper _mapper;

        public TextCardsController(ITextCardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TextCardViewModel>>> GetCards()
        {
            var cardList = await _cardRepository.GetAll();

            return _mapper.Map<List<TextCardViewModel>>(cardList); ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TextCardViewModel>> GetCard(int id)
        {
            var card = await _cardRepository.GetById(id);

            if (card == null)
                return NotFound();

            return _mapper.Map<TextCardViewModel>(card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, TextCardViewModel card)
        {
            if (id != card.CardId)
                return BadRequest();

            var cardModel = _mapper.Map<TextCard>(card);
            await _cardRepository.Update(cardModel);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostCard(TextCardViewModel card)
        {
            var cardModel = _mapper.Map<TextCard>(card);

            await _cardRepository.Add(cardModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            await _cardRepository.Remove(id);

            return NoContent();
        }
    }
}
