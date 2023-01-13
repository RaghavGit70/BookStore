using BookWebApp.Models;

namespace BookWebApp.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}