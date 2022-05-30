using BookManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public class BookService : IBookService
    {
        BookContext context;
        public BookService(BookContext _context)
        {
            context = _context;
        }
        public void Insert(Books book)
        {
            context.books.Add(book);
            context.SaveChanges();
        }
        public List<Books> Load()
        {
            List<Books> libook = context.books.Include("category").Include("authors").ToList();
            return libook;
        }
        public void Delete(int ID)
        {
            Books book = new Books();
            book = context.books.Find(ID);
            context.books.Remove(book);
            context.SaveChanges();


        }
       /* public Books Loadbyid(int ID)
        {
            Books book = new Books();
            book = context.books.Where(x => x.ID == ID).FirstOrDefault();
            return book;
        }*/
        public Books Edit(int ID)
        {
            Books book = new Books();
            book = context.books.Find(ID);
            return book;
        }
        public void Update(Books book)
        {
            context.books.Attach(book);
            context.Entry(book).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
