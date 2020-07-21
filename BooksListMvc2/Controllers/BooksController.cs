using BooksListMvc2.Data;
using BooksListMvc2.Models;
using BooksListMvc2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BooksListMvc2.Controllers {
    public class BooksController : Controller {

        private readonly BookService _bookService;
         private readonly CategoryService _categoryService;
        public BooksController(BookService bookService, CategoryService categoryService) {
            _bookService = bookService;
            _categoryService = categoryService;
        }




        [HttpGet]
        public IActionResult Index() {
            return View(_bookService.FindAll());
        }

        [HttpGet]
        public IActionResult Create() {
            var allCategories = _categoryService.FindAll();
            var modelView = new BookFormViewModel() { Categories = allCategories };
            return View(modelView);
        }


        [HttpPost]
        public IActionResult Create(Book book) {
            _bookService.AddBook(book);
            return RedirectToAction(nameof(Index));
        }


    }
}
