
using Test2.Data;
using Test2.Interface;
using Test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2.Service
{
    public class BookService
    {
        private readonly IRepository<Book> _book;
        public BookService(IRepository<Book> book)
        {
            _book = book;
        }
        //Get Books Details By Book Id
        public async Task<Book> GetById(int? BookId)
        {
            return  _book.GetById(BookId);
        }
       
        //GET All Books Details 
        public  IEnumerable<Book> GetAllBooks()
        {
            try
            {
                return  _book.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Add Book
        public async Task<Book> AddBook(Book Book)
        {
            return await _book.Create(Book);
        }
        //Delete Book 
        public async Task<bool> DeleteBook(int BookID)
        {

            try
            {
                var item =  _book.GetById(BookID);
                 _book.Delete(item);
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Update Book Details
        public async Task<bool> UpdateBook(Book book)
        {
            try
            {
                 _book.Update(book);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public IEnumerable<Genre> GetAllGenre()
        {
            return _book.GetGerne();
        }
        public List<Book> GetSearch(string searchText)
        {
            return _book.GetSearch(searchText);
        }

        // Exists Book
        public bool Exists(int id)
        {
            return _book.Exists(id);
        }
    }
}