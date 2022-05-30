using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Data
{
    [Table("Authors")]
    public class Authors
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Fill First Name to Continue.")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Please Fill Last Name to Continue.")]
        public string Lname { get; set; }
        [RegularExpression(@"07(7|8|9)\d{7}")]
        public string Phone { get; set; }
        [ForeignKey("nationality")]
        public int nationality_ID { get; set; }
        public Nationality nationality { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Imagepath { get; set; }
        public List<Books> libook { get; set; }
    }
}
