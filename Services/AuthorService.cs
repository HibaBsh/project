using BookManagement.Data;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public class AuthorService : IAuthorService
    {
        BookContext context;
        public AuthorService(BookContext _context)
        {
            context = _context;
        }
        public List<Authors> LoadAuthors()
        {
            List<Authors> liauthor = context.authors.ToList();
            return liauthor;
        }

        public void Insert(Authors auth)
        {
            context.authors.Add(auth);
            context.SaveChanges();
        }
        public void Delete(int ID)
        {
            Authors author = new Authors();
            author = context.authors.Find(ID);
            context.authors.Remove(author);
            context.SaveChanges();


        }
        public Authors Edit(int ID)
        {
            Authors author = new Authors();
            author = context.authors.Find(ID);
            return author;
        }
        public Authors Loadbyid(int ID)
        {
            return context.authors.Where(x => x.ID == ID).FirstOrDefault();
        }
        public void Update(Authors author)
        {
            context.authors.Attach(author);
            context.Entry(author).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
