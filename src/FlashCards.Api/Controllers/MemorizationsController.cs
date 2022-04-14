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
    public class MemorizationsController : ControllerBase
    {
        private readonly IMemorizationRepository _memorizationRepository;
        private readonly IMapper _mapper;

        public MemorizationsController(IMemorizationRepository memorizationRepository, IMapper mapper)
        {
            _memorizationRepository = memorizationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemorizationViewModel>>> GetMemorizations()
        {
            var memorizationList = await _memorizationRepository.GetAll();
            return _mapper.Map<List<MemorizationViewModel>>(memorizationList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemorizationViewModel>> GetMemorization(int id)
        {
            var memorization = await _memorizationRepository.GetById(id);

            if (memorization == null)
                return NotFound();

            return _mapper.Map<MemorizationViewModel>(memorization);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMemorization(int id, MemorizationViewModel memorization)
        {
            if (id != memorization.MemorizationId)
                return BadRequest();

            var memorizationModel = _mapper.Map<Memorization>(memorization);
            await _memorizationRepository.Update(memorizationModel);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostMemorization(MemorizationViewModel memorization)
        {
            var memorizationModel = _mapper.Map<Memorization>(memorization);

            await _memorizationRepository.Add(memorizationModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMemorization(int id)
        {
            await _memorizationRepository.Remove(id);
            return NoContent();
        }
    }
}
