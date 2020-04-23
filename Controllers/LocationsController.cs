using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcoU.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoU.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ProjectContext db;

        public LocationsController(ProjectContext context)
        {
            db = context;
        }

        public IActionResult getRegions()
        {
            var regions = Location.getRegions();
            return Ok(regions);
        }

        public IActionResult getTowns(string region)
        {
            var locations = db.Locations.Where(p => p.Region == region);
            return Ok(locations);
        }

    }
}
