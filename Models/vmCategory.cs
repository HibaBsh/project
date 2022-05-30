using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class vmCategory
    {
        public Category category { get; set; }
        public List<Category> licategory { get; set; }
    }
}
