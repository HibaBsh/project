using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class vmAuthor
    {
        public Authors author { get; set; }
        public List<Authors> liauthor { get; set; }
        public List<Nationality> linationality { get; set; }
    }
}
