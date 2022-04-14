using FlashCards.Business.Models;

namespace FlashCards.Business.Interfaces
{
    public interface IDeckRepository : IRepository<Deck>
    {
        Task<Deck> GetDeckAndCards(int id);
    }
}
