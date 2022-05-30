using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService cService;
        public CategoryController(ICategoryService _cService)
        {
            cService = _cService;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            vmCategory vm = new vmCategory();
            vm.licategory = cService.Load();
            return View("CategoryList",vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(vmCategory vm)
        {
            cService.Insert(vm.category);
            vm.licategory = cService.Load();
            return View("CategoryList", vm);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int ID)
        {
            vmCategory vm = new vmCategory();
            cService.Delete(ID);
            vm.licategory = cService.Load();
            return View("CategoryList", vm);
        }
    }
}
