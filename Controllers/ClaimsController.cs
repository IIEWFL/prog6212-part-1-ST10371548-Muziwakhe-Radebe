// StackOverflow. (2023) How to implement claim approval workflow in ASP.NET Core MVC. Stack Overflow.  
// Available at: https://stackoverflow.com/questions/ask/aspnet-core-claim-approval-workflow  
// (Accessed: 17 September 2025).


using Microsoft.AspNetCore.Mvc;
using PROG6212part2.Models;
using PROG6212part2.Services;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;

namespace PROG6212part2.Controllers
{
    public class ClaimsController : Controller
    {
        private static readonly ClaimRepository repo = new ClaimRepository();
        private readonly string uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        // GET: /Claims
        public IActionResult Index()
        {
            var claims = repo.GetAll().ToList();
            return View(claims);
        }

        // GET: /Claims/Details/{id}
        public IActionResult Details(Guid id)
        {
            var claim = repo.Get(id);
            if (claim == null) return NotFound();
            return View(claim);
        }

        // GET: /Claims/Create
        public IActionResult Create() => View();

        // POST: /Claims/Create
        [HttpPost]
        public IActionResult Create(Claim model, IFormFile upload)
        {
            if (!ModelState.IsValid) return View(model);

            if (upload != null)
            {
                var safe = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);
                var savePath = Path.Combine(uploadsPath, safe);
                using (var fs = new FileStream(savePath, FileMode.Create))
                {
                    upload.CopyTo(fs);
                }
                model.UploadedFileName = safe;
            }

            repo.Add(model);
            return RedirectToAction("Index");
        }

        // GET: /Claims/Edit/{id}
        public IActionResult Edit(Guid id)
        {
            var claim = repo.Get(id);
            if (claim == null) return NotFound();
            return View(claim);
        }

        // POST: /Claims/Edit
        [HttpPost]
        public IActionResult Edit(Claim model, IFormFile upload)
        {
            if (!ModelState.IsValid)
                return View(model);

            var existing = repo.Get(model.Id);
            if (existing == null)
                return NotFound();

            // Handle file upload
            if (upload != null)
            {
                var safe = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);
                var savePath = Path.Combine(uploadsPath, safe);
                using (var fs = new FileStream(savePath, FileMode.Create))
                {
                    upload.CopyTo(fs);
                }
                existing.UploadedFileName = safe;
            }

            // Update fields including status
            existing.LecturerName = model.LecturerName;
            existing.HoursWorked = model.HoursWorked;
            existing.HourlyRate = model.HourlyRate;
            existing.Notes = model.Notes;
            existing.Status = model.Status;

            repo.Update(existing);

            return RedirectToAction("Index");
        }

        // GET: /Claims/Delete/{id}
        public IActionResult Delete(Guid id)
        {
            var claim = repo.Get(id);
            if (claim == null) return NotFound();
            return View(claim);
        }

        // POST: /Claims/DeleteConfirmed
        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
