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
    public class ContractsController : Controller
    {
        private readonly BlogicDbContext _context;

        public ContractsController(BlogicDbContext context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            var blogicDbContext = _context.Contracts.Include(c => c.Client).Include(c => c.Consultant);
            return View(await blogicDbContext.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Client)
                .Include(c => c.Consultant)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FullName");
            ViewData["ConsultantID"] = new SelectList(_context.Consultants, "ConsultantID", "Name");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,EvidenceNumber,Institution,ClientID,ConsultantID,CloseDate,ExpiDate,EndDate")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FullName", contract.ClientID);
            ViewData["ConsultantID"] = new SelectList(_context.Consultants, "ConsultantID", "Name", contract.ConsultantID);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FullName", contract.ClientID);
            ViewData["ConsultantID"] = new SelectList(_context.Consultants, "ConsultantID", "Name", contract.ConsultantID);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EvidenceNumber,Institution,ClientID,ConsultantID,CloseDate,ExpiDate,EndDate")] Contract contract)
        {
            if (id != contract.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.ID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "FullName", contract.ClientID);
            ViewData["ConsultantID"] = new SelectList(_context.Consultants, "ConsultantID", "FullName", contract.ConsultantID);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Client)
                .Include(c => c.Consultant)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.ID == id);
        }

        //public IActionResult ExportCSV()
        //{
        //    StringBuilder s = new StringBuilder();
        //    s.AppendLine("EvidenceNumber, Institution, Client, Consultant, CloseDate, ExpiDate, EndDate");
        //    foreach (Contract contract in _context.Contracts)
        //    {
        //        Client client = _context.Clients.FirstOrDefault(e => e.ClientID == contract.ClientID);
        //        Consultant consultant = _context.Consultants.FirstOrDefault(e => e.ConsultantID == contract.ConsultantID);
        //        s.AppendLine($"{contract.EvidenceNumber},{contract.Institution},{client.Name},{consultant.Name},{contract.CloseDate},{contract.ExpiDate},{contract.EndDate}");
        //    }
        //    return File(Encoding.UTF32.GetBytes(s.ToString()), "text/csv", $"ConsultantExport{DateTime.Now}.csv");
        //}
    }
}
