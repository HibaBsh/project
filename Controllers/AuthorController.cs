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
    public class AuthorController : Controller
    {
        IAuthorService aService;
        INationalityService nService;
        public AuthorController(IAuthorService _aService, INationalityService _nService)
        {
            aService = _aService;
            nService = _nService;

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            vmAuthor vm = new vmAuthor();
            vm.liauthor = aService.LoadAuthors();
            vm.linationality = nService.Load();

            return View("AuthorList", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(vmAuthor vm)
        {
            string name = Guid.NewGuid().ToString() + "." + vm.author.Image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
            vm.author.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.author.Imagepath = "http://localhost/BookManagement/StaticPath/" + name;
            aService.Insert(vm.author);
            vm.linationality = nService.Load();
            vm.liauthor = aService.LoadAuthors();

            return View("AuthorList", vm);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int ID)
        {
            vmAuthor vm = new vmAuthor();
            vm.linationality = nService.Load();
            
            aService.Delete(ID);
            vm.liauthor = aService.LoadAuthors();
            return View("AuthorList", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int ID)
        {
            Authors author = new Authors();
            author = aService.Edit(ID);
            return Json(author);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Update(vmAuthor VM)
        {
            if (VM.author.Image != null)
            {
                string name = Guid.NewGuid().ToString() + "." + VM.author.Image.FileName.Split('.')[1];
                string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", name);
                VM.author.Image.CopyTo(new FileStream(path, FileMode.Create));
                VM.author.Imagepath = "http://localhost/BookManagement/StaticPath/" + name;
            }
            aService.Update(VM.author);
            vmAuthor vm = new vmAuthor();
            vm.linationality = nService.Load();
            vm.liauthor = aService.LoadAuthors();
            
            
            return View("AuthorList", vm);
        }
    }
}
