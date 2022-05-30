using BookManagement.Models;
using BookManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Controllers
{
    public class NationalityController : Controller
    {
        INationalityService nService;

        public NationalityController(INationalityService _nService)
        {
            nService = _nService;
        }


        public IActionResult Index()
        {
            vmNationality vm = new vmNationality();
            vm.linationality = nService.Load();
            return View("NationalityList", vm);
        }

        public IActionResult Save(vmNationality vm)
        {
            nService.Insert(vm.nationality);
            vm.linationality = nService.Load();
            return View("NationalityList", vm);


        }
    }
}
