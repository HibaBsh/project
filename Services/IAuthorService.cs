using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Services
{
   public interface IAuthorService
    {
        List<Authors> LoadAuthors();
        void Insert(Authors auth);
         void Delete(int ID);
         Authors Edit(int ID);
         Authors Loadbyid(int ID);
        void Update(Authors author);
    }
}
