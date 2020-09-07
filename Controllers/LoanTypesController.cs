using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyFinance.Models;

namespace EasyFinance.Controllers
{
    public class LoanTypesController : Controller
    {
        private readonly LoanTypeContext _context;

        public LoanTypesController(LoanTypeContext context)
        {
            _context = context;
        }

        // GET: LoanTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoanTypes.ToListAsync());
        }

        // GET: LoanTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanTypes = await _context.LoanTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loanTypes == null)
            {
                return NotFound();
            }

            return View(loanTypes);
        }

        // GET: LoanTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoanTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,CreatedAt,UpdatedAt")] LoanTypes loanTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loanTypes);
        }

        // GET: LoanTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanTypes = await _context.LoanTypes.FindAsync(id);
            if (loanTypes == null)
            {
                return NotFound();
            }
            return View(loanTypes);
        }

        // POST: LoanTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,CreatedAt,UpdatedAt")] LoanTypes loanTypes)
        {
            if (id != loanTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanTypesExists(loanTypes.Id))
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
            return View(loanTypes);
        }

        // GET: LoanTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var loantype = await _context.LoanTypes.FindAsync(id);

            _context.LoanTypes.Remove(loantype);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //// POST: LoanTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var loanTypes = await _context.LoanTypes.FindAsync(id);
        //    _context.LoanTypes.Remove(loanTypes);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool LoanTypesExists(int id)
        {
            return _context.LoanTypes.Any(e => e.Id == id);
        }
    }
}
