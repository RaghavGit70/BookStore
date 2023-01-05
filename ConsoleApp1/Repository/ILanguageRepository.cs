using ConsoleApp1.Models;

namespace ConsoleApp1.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}