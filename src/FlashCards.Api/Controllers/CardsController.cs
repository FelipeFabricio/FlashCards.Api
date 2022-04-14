#nullable disable
using AutoMapper;
using FlashCards.Api.ViewModels;
using FlashCards.Business.Interfaces;
using FlashCards.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardsController(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardViewModel>>> GetCards()
        {
            var cardList = await _cardRepository.GetAll();

            return _mapper.Map<List<CardViewModel>>(cardList); ;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardViewModel>> GetCard(int id)
        {
            var card = await _cardRepository.GetById(id);

            if (card == null)
                return NotFound();

            return _mapper.Map<CardViewModel>(card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, CardViewModel card)
        {
            if (id != card.CardId)
                return BadRequest();

            var cardModel = _mapper.Map<Card>(card);
            await _cardRepository.Update(cardModel);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostCard(CardViewModel card)
        {
            var cardModel = _mapper.Map<Card>(card);

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
