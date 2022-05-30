using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Data
{
    [Table("Nationality")]
    public class Nationality
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
