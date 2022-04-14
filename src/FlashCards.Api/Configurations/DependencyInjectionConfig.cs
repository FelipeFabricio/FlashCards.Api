using FlashCards.Business.Interfaces;
using FlashCards.Data.Repository;

namespace FlashCards.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection service)
        {
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            service.AddScoped<IDeckRepository, DeckRepository>();
            service.AddScoped<ICardRepository, CardRepository>();
            service.AddScoped<IMemorizationRepository, MemorizationRepository>();

            return service;
        }
    }
}
