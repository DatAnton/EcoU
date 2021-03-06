﻿using System;
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
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace EcoU.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Show(int? id)
        {
            if (id == null)
                return BadRequest();

            CleaningPlan cleaningPlan = db.CleaningPlans.Include(p => p.Location)
                .Include(p => p.Creator)
                .FirstOrDefault(p => p.Id == id);
            if (cleaningPlan == null)
                return NotFound();

            ViewBag.CurrectUserId = userManager.GetUserId(HttpContext.User);
            return View(cleaningPlan);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            CleaningPlan plan = db.CleaningPlans
                .Include(p => p.Location).FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();
            if (plan.CreatorId != userManager.GetUserId(HttpContext.User))
                return BadRequest();

            CleanPlanViewModel model = new CleanPlanViewModel
            {
                Id = plan.Id,
                Describing = plan.Describing,
                PlanName = plan.PlanName,
                PlanDate = plan.PlanDate,
                Address = plan.Address,
                Location = plan.Location,
                MainPhotoString = plan.MainPhoto,
                LocationId = plan.LocationId,
                CreatorId = plan.CreatorId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CleanPlanViewModel model)
        {
            Console.WriteLine(model.CreatorId);

            if (model.CreatorId != userManager.GetUserId(HttpContext.User))
                return BadRequest();

            CleaningPlan plan = new CleaningPlan
            {
                Id = model.Id,
                PlanName = model.PlanName,
                Describing = model.Describing,
                Address = model.Address,
                LocationId = model.LocationId,
                PlanDate = model.PlanDate,
                CreatorId = userManager.GetUserId(HttpContext.User)
            };

            if (model.MainPhoto != null)
            {
                if (!string.IsNullOrEmpty(model.MainPhotoString))
                {
                    string path = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    string filePath = Path.Combine(path, model.MainPhotoString);
                    System.IO.File.Delete(filePath);
                }
                plan.MainPhoto = UploadFile(model);
            }
            else
            {
                plan.MainPhoto = model.MainPhotoString;
            }
                

            db.CleaningPlans.Update(plan);
            db.SaveChanges();
            return RedirectToAction("Show", new { id = plan.Id});
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            CleaningPlan plan = db.CleaningPlans.FirstOrDefault(p => p.Id == id);
            if (plan != null)
            {
                if (plan.CreatorId != userManager.GetUserId(HttpContext.User))
                    return BadRequest();
                else {
                    string path = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    string filePath = Path.Combine(path, plan.MainPhoto);
                    System.IO.File.Delete(filePath);

                    db.CleaningPlans.Remove(plan);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index(int? locationId, string planNameFind, string locationRegion)
        {
            //finding by all region?

            IQueryable<CleaningPlan> cleaningPlans = db.CleaningPlans
                .Include(p => p.Location);

            if (locationId != null && locationId > 0)
                cleaningPlans = cleaningPlans.Where(p => p.LocationId == locationId);

            else if(locationId == 0 && !string.IsNullOrEmpty(locationRegion))
            {
                if(locationRegion != "All country")
                    cleaningPlans = cleaningPlans.Where(p => p.Location.Region == locationRegion);
            }


            if (!string.IsNullOrEmpty(planNameFind))
            {
                cleaningPlans = cleaningPlans
                    .Where(p => p.PlanName.ToLower().Contains(planNameFind.ToLower()));
            }

            IndexPlansModel model = new IndexPlansModel
            {
                Plans = cleaningPlans.ToList(),
                PlanNameFind = planNameFind,
                LocationRegionFind = locationRegion,
                LocationId = locationId
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                return RedirectToAction("Index", "CleaningPlans");
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
