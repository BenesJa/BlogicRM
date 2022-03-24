using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogicRM.Models.Database;
using BlogicRM.Models.Entity;
using System.Text;

namespace BlogicRM.Controllers
{
    public class ConsultantsController : Controller
    {
        private readonly BlogicDbContext _context;

        public ConsultantsController(BlogicDbContext context)
        {
            _context = context;
        }

        // GET: Consultants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Consultants.ToListAsync());
        }

        // GET: Consultants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants
                .FirstOrDefaultAsync(m => m.ConsultantID == id);
            if (consultant == null)
            {
                return NotFound();
            }
            
            return View(consultant);
        }

        // GET: Consultants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Consultants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Email,PhoneNumber,IdentificationNumber,Age")] Consultant consultant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(consultant);
        }

        // GET: Consultants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants.FindAsync(id);
            if (consultant == null)
            {
                return NotFound();
            }
            return View(consultant);
        }

        // POST: Consultants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Email,PhoneNumber,IdentificationNumber,Age")] Consultant consultant)
        {
            if (id != consultant.ConsultantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultantExists(consultant.ConsultantID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(consultant);
        }

        // GET: Consultants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultant = await _context.Consultants
                .FirstOrDefaultAsync(m => m.ConsultantID == id);
            if (consultant == null)
            {
                return NotFound();
            }

            return View(consultant);
        }

        // POST: Consultants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultant = await _context.Consultants.FindAsync(id);
            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultantExists(int id)
        {
            return _context.Consultants.Any(e => e.ConsultantID == id);
        }

        public IActionResult ExportCSV()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("FirstName, LastName, Email, PhoneNumber, IdentificationNumber, Age");
            foreach (Consultant consultant in _context.Consultants)
            {
                s.AppendLine($"{consultant.FirstName},{consultant.LastName},{consultant.Email},{consultant.PhoneNumber},{consultant.IdentificationNumber},{consultant.Age}");
            }
            return File(Encoding.UTF32.GetBytes(s.ToString()), "text/csv", $"ConsultantExport{DateTime.Now}.csv");
        }
    }
}
