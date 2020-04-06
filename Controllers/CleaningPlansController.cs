using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcoU.Models;

namespace EcoU.Controllers
{
    public class CleaningPlansController : Controller
    {
        private readonly ProjectContext db;

        public CleaningPlansController(ProjectContext context)
        {
            db = context;
        }

        public IActionResult Create()
        {
            return View();
        }


    }
}
