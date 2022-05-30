using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Services
{
    public class NationalityService : INationalityService
    {
        BookContext context;
        public NationalityService(BookContext _context)
        {
            context = _context;
        }
        public List<Nationality> Load()
        {
            List<Nationality> linationality = context.nationalities.ToList();
            return linationality;
        }

        public void Insert(Nationality n)
        {
            context.nationalities.Add(n);
            context.SaveChanges();
        }
    }
}
