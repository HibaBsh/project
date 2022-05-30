using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class vmBook
    {
        public Books books { get; set; }
        public List<Books> libook { get; set; }
        public List<Authors> liauthor { get; set; }
        public List<Category> licat { get; set; }
    }
}
