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



        //Index
        [HttpGet]
        public IActionResult Index() {
            return View(_bookService.FindAll());
        }


        //Create
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


        //Edit
        [HttpGet]
        public IActionResult Edit(int id) {
            var book = _bookService.Find(id);
            var categories = _categoryService.FindAll();
            var viewModel = new BookFormViewModel() { Book = book, Categories = categories };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(Book book) {
            if (ModelState.IsValid) {
                _bookService.UpdateBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        //Delete
        public IActionResult Delete(int id) {
            var bookToDelete = _bookService.Find(id);
            _bookService.DeleteBook(bookToDelete);
            return RedirectToAction(nameof(Index));
        }

    }
}
