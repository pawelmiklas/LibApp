using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp.Models;
using LibApp.ViewModels;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Random()
        {
            var firstBook = new Book()
            {
                Name = "English dictionary"
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"},
            };

            var viewModel = new RandomBookViewModel
            {
                Book = firstBook,
                Customers = customers
            };

            return View(viewModel);
        }

        public IActionResult Edit(int BookId)
        {
            return Content("id=" + BookId);
        }

        public IActionResult Index()
        {
            var books = _context.Books.Include(c => c.Genre).ToList();

            return View(books);
        }

        [Route("books/released/{year:regex(^\\d{{4}}$):min(1925):max(2021)}/{month:range(1,12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
