using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Services
{
   public interface INationalityService
    {
        public List<Nationality> Load();
        public void Insert(Nationality n);
    }
}
