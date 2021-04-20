using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Interface;
using Test2.Models;
using Test2.Service;

namespace Test2.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IRepository<Book> _Book;
        private readonly BookService bookService;

        public BooksController(IRepository<Book> book, BookService _bookService)
        {
            _Book = book;
            bookService = _bookService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(bookService.GetAllBooks());
        }
        // POST: Books
        [HttpPost]
        public async Task<IActionResult> Index(string searchText)
        {
            return View(bookService.GetSearch(searchText));
        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(bookService.GetAllGenre(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AuthorBook,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                await bookService.AddBook(book);
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(bookService.GetAllGenre(), "Id", "Name", book.GenreId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(bookService.GetAllGenre(), "Id", "Name", book.GenreId);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AuthorBook,GenreId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await bookService.UpdateBook(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(bookService.GetAllGenre(), "Id", "Name", book.GenreId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return bookService.Exists(id);
        }
    }
}

