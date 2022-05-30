using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public interface IBookService
    {
         void Insert(Books book);
         List<Books> Load();
         void Delete(int ID);
        /* Books Loadbyid(int ID);*/
         Books Edit(int ID);
         void Update(Books book);
    }
}
