using BookManagement.Data;
using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    public class BookController : Controller
    {
        IBookService bService;
        ICategoryService cService;
        IAuthorService aService;
        public BookController(IBookService _bService, ICategoryService _cService, IAuthorService _aService)
        {
            bService = _bService;
            cService = _cService;
            aService = _aService;

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            vmBook vm = new vmBook();
            vm.liauthor = aService.LoadAuthors();
            vm.licat = cService.Load();
            vm.libook = bService.Load();
            return View("BookList", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(vmBook vm)
        {
            string name = Guid.NewGuid().ToString() + "." + vm.books.Image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
            vm.books.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.books.Imagepath = "http://localhost/BookManagement/StaticPath/" + name;
            bService.Insert(vm.books);
            vm.liauthor = aService.LoadAuthors();
            vm.licat = cService.Load();
            vm.libook = bService.Load();
            return View("BookList", vm);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int ID)
        {
            vmBook vm = new vmBook();
            vm.liauthor = aService.LoadAuthors();
            vm.licat = cService.Load();
            bService.Delete(ID);
            vm.libook = bService.Load();
            return View("BookList", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int ID)
        {
            Books book = new Books();
            book = bService.Edit(ID);
            return Json(book);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(vmBook VM)
        {
            
            if (VM.books.Image != null) 
            {
                string name = Guid.NewGuid().ToString() + "." + VM.books.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                VM.books.Image.CopyTo(new FileStream(path, FileMode.Create));
                VM.books.Imagepath = "http://localhost/BookManagement/StaticPath/" + name;
            }
           
                

            bService.Update(VM.books);
            vmBook vm = new vmBook();
            vm.liauthor = aService.LoadAuthors();
            vm.licat = cService.Load();
            vm.libook = bService.Load();
            return View("BookList", vm);
        }
    }
}
