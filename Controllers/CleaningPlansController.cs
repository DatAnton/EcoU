using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EcoU.Models;
using EcoU.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace EcoU.Controllers
{
    public class CleaningPlansController : Controller
    {
        private readonly ProjectContext db;
        private readonly UserManager<User> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CleaningPlansController(ProjectContext context, UserManager<User> manager, IWebHostEnvironment webHost)
        {
            db = context;
            userManager = manager;
            webHostEnvironment = webHost;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(CleanPlanViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = userManager.GetUserId(HttpContext.User);
                string uniqueFileName = UploadFile(model);
                CleaningPlan cleaningPlan = new CleaningPlan
                {
                    PlanName = model.PlanName,
                    Describing = model.Describing,
                    CreatorId = userId,
                    PlanDate = model.PlanDate,
                    LocationId = model.LocationId,
                    Address = model.Address,
                    MainPhoto = uniqueFileName
                };
                db.CleaningPlans.Add(cleaningPlan);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private string UploadFile(CleanPlanViewModel model)
        {
            string uniqueFileName = null;
            if (model.MainPhoto != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.MainPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.MainPhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}
