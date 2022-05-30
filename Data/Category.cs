using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Data
{
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }
        public string Catcode { get; set; }

        [Required(ErrorMessage = "Please Fill Category Name to Continue.")]
        public string Name { get; set; }
        public List<Books> libook { get; set; }
    }
}
