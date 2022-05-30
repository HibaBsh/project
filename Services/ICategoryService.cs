using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Services
{
   public interface ICategoryService
    {
        public List<Category> Load();
        public void Insert(Category cat);
        public void Delete(int ID);
    }
}
