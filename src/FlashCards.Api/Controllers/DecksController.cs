#nullable disable
using AutoMapper;
using FlashCards.Api.ViewModels;
using FlashCards.Business.Interfaces;
using FlashCards.Business.Models;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace FlashCards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecksController : ControllerBase
    {
        private readonly IDeckRepository _deckRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _log;

        public DecksController(IDeckRepository deckRepository, IMapper mapper, ILogger log)
        {
            _deckRepository = deckRepository;
            _mapper = mapper;
            _log = log;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeckViewModel>>> GetDecks()
        {
            var deckList = await _deckRepository.GetAll();

            return _mapper.Map<List<DeckViewModel>>(deckList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeckViewModel>> GetDeck(int id)
        {
            var deck = await _deckRepository.GetById(id);

            if (deck == null)
                return NotFound();

            return _mapper.Map<DeckViewModel>(deck);
        }

        [HttpGet("deck-cards/{id}")]
        public async Task<ActionResult<DeckViewModel>> GetDeckCards(int id)
        {
            var deckAndCards = await _deckRepository.GetDeckAndCards(id);

            if (deckAndCards == null)
                return NotFound();

            _log.Information($"Cadastro OK => Deck: {deckAndCards.Description} - Id:{deckAndCards.DeckId}");
            return _mapper.Map<DeckViewModel>(deckAndCards);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeck(int id, DeckViewModel deck)
        {
            if (id != deck.DeckId)
                return BadRequest();

            var deckModel = _mapper.Map<Deck>(deck);
            await _deckRepository.Update(deckModel);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostDeck(DeckViewModel deck)
        {
            var deckModel = _mapper.Map<Deck>(deck);
            await _deckRepository.Add(deckModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeck(int id)
        {
            await _deckRepository.Remove(id);
            return NoContent();
        }
    }
}
