using Test2.Data;
using Test2.Interface;
using Test2.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test2.Repository
{
    public class RepositoryBook : IRepository<Book>
    {
        public async Task<Book> Create(Book book)
        {
            _dbcontext.Add(book);
            await _dbcontext.SaveChangesAsync();
            return book;
        }

        public void Delete(Book book)
        {
            _dbcontext.Books.Remove(book);
             _dbcontext.SaveChangesAsync();
        }

        public IEnumerable<Book> GetAll()
        {
            return  _dbcontext.Books.Include(b => b.Genre).ToList();
        }
        
        public Book GetById(int? Id)
        {
            return  _dbcontext.Books.Find(Id);
        }

        

        public void Update(Book book)
        {
            _dbcontext.Update(book);
             _dbcontext.SaveChangesAsync();
        }

        public bool Exists(int Id)
        {
            return _dbcontext.Books.Any(x=>x.Id==Id);
        }

        public  List<Book>  GetSearch(string search)
        {
            return _dbcontext.Books
                .Include(b => b.Genre)
                .Where(x => x.Name == search).ToList();
        }

        public IEnumerable<Genre> GetGerne()
        {
            return _dbcontext.Genres.ToList();
        }

        ApplicationDbContext _dbcontext;
        public RepositoryBook(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        
    }
}
