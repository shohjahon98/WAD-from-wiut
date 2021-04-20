using Test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Interface
{
    public interface IRepository<T>
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int? Id);

        public void Delete(T _object);
        public List<Book> GetSearch(string search);
        public IEnumerable<Genre> GetGerne();
        public bool Exists(int Id);

    }
}
