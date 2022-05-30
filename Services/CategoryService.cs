using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public class CategoryService : ICategoryService
    {
        BookContext context;
        public CategoryService(BookContext _context)
        {
            context = _context;
        }
        public List<Category> Load()
        {
            List<Category> licat = context.categories.ToList();
            return licat;
        }

        public void Insert(Category cat)
        {
            context.categories.Add(cat);
            context.SaveChanges();
        }
        public void Delete(int ID)
        {
            Category cat = new Category();
            cat = context.categories.Find(ID);
            context.categories.Remove(cat);
            context.SaveChanges();
        }
    }
}
