using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobTrackerApp.Data;
using JobTrackerApp.Models;

namespace JobTrackerApp.Controllers
{
    public class Job_ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Job_ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Job_Contact
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Job_Contact.Include(j => j.Contact).Include(j => j.Job);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Job_Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Contact = await _context.Job_Contact
                .Include(j => j.Contact)
                .Include(j => j.Job)
                .SingleOrDefaultAsync(m => m.Job_ContactId == id);
            if (job_Contact == null)
            {
                return NotFound();
            }

            return View(job_Contact);
        }

        // GET: Job_Contact/Create
        public IActionResult Create()
        {
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "POC_firstName");
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Job_Post_Url");
            return View();
        }

        // POST: Job_Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Job_ContactId,JobId,ContactId")] Job_Contact job_Contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job_Contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "POC_firstName", job_Contact.ContactId);
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Job_Post_Url", job_Contact.JobId);
            return View(job_Contact);
        }

        // GET: Job_Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Contact = await _context.Job_Contact.SingleOrDefaultAsync(m => m.Job_ContactId == id);
            if (job_Contact == null)
            {
                return NotFound();
            }
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "POC_firstName", job_Contact.ContactId);
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Job_Post_Url", job_Contact.JobId);
            return View(job_Contact);
        }

        // POST: Job_Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Job_ContactId,JobId,ContactId")] Job_Contact job_Contact)
        {
            if (id != job_Contact.Job_ContactId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job_Contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Job_ContactExists(job_Contact.Job_ContactId))
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
            ViewData["ContactId"] = new SelectList(_context.Contact, "ContactId", "POC_firstName", job_Contact.ContactId);
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Job_Post_Url", job_Contact.JobId);
            return View(job_Contact);
        }

        // GET: Job_Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job_Contact = await _context.Job_Contact
                .Include(j => j.Contact)
                .Include(j => j.Job)
                .SingleOrDefaultAsync(m => m.Job_ContactId == id);
            if (job_Contact == null)
            {
                return NotFound();
            }

            return View(job_Contact);
        }

        // POST: Job_Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var job_Contact = await _context.Job_Contact.SingleOrDefaultAsync(m => m.Job_ContactId == id);
            _context.Job_Contact.Remove(job_Contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Job_ContactExists(int id)
        {
            return _context.Job_Contact.Any(e => e.Job_ContactId == id);
        }
    }
}
