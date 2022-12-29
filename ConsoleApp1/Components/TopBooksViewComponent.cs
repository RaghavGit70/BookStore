using ConsoleApp1.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly BookRepository _bookRepository;

        public TopBooksViewComponent(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            
            var books = await _bookRepository.GetTopBooksAsync(count);
            return View(books);
        }

    }
}
