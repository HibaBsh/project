using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Data
{
    [Table("Books")]
    public class Books
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Fill Book Title to Continue. ")]
        public string Title { get; set; }
        public int Year { get; set; }
        [Required(ErrorMessage = "Please Fill Book Price to Continue. ")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please Fill How many books in stock !!")]
        public int Stock { get; set; }
        [ForeignKey("category")]
        public int category_ID { get; set; }
        public Category category { get; set; }
        [ForeignKey("authors")]
        public int authors_ID { get; set; }
        public Authors authors { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Imagepath { get; set; }
       
    }
}
