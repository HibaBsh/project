using BookManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Models
{
    public class vmNationality
    {
        public Nationality nationality { get; set; }
        public List<Nationality> linationality { get; set; }
    }
}
