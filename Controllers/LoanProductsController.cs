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
    public class LoanProductsController : Controller
    {
        private readonly LoanProductContext _context;

        public LoanProductsController(LoanProductContext context)
        {
            _context = context;
        }

        // GET: LoanProducts
        public async Task<IActionResult> Index()
        {
            var loanProductContext = _context.LoanProduct.Include(l => l.Banks).Include(l => l.LoanTypes);
            return View(await loanProductContext.ToListAsync());
        }

        // GET: LoanProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanProduct = await _context.LoanProduct
                .Include(l => l.Banks)
                .Include(l => l.LoanTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loanProduct == null)
            {
                return NotFound();
            }

            return View(loanProduct);
        }

        // GET: LoanProducts/Create
        public IActionResult Create()
        {
            ViewData["BankId"] = new SelectList(_context.Set<Banks>(), "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.Set<LoanTypes>(), "Id", "Name");
            return View();
        }

        // POST: LoanProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TypeId,BankId,InterestRate,Summary,FinancialMin,FinancialMax,TenureMin,TenureMax,AgeMin,AgeMax,CreatedAt,UpdatedAt")] LoanProduct loanProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BankId"] = new SelectList(_context.Set<Banks>(), "Id", "Name", loanProduct.BankId);
            ViewData["TypeId"] = new SelectList(_context.Set<LoanTypes>(), "Id", "Name", loanProduct.TypeId);
            return View(loanProduct);
        }

        // GET: LoanProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanProduct = await _context.LoanProduct.FindAsync(id);
            if (loanProduct == null)
            {
                return NotFound();
            }
            ViewData["BankId"] = new SelectList(_context.Set<Banks>(), "Id", "Name", loanProduct.BankId);
            ViewData["TypeId"] = new SelectList(_context.Set<LoanTypes>(), "Id", "Name", loanProduct.TypeId);
            return View(loanProduct);
        }

        // POST: LoanProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TypeId,BankId,InterestRate,Summary,FinancialMin,FinancialMax,TenureMin,TenureMax,AgeMin,AgeMax,CreatedAt,UpdatedAt")] LoanProduct loanProduct)
        {
            if (id != loanProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanProductExists(loanProduct.Id))
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
            ViewData["BankId"] = new SelectList(_context.Set<Banks>(), "Id", "Name", loanProduct.BankId);
            ViewData["TypeId"] = new SelectList(_context.Set<LoanTypes>(), "Id", "Name", loanProduct.TypeId);
            return View(loanProduct);
        }

        // GET: LoanProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanProduct = await _context.LoanProduct
                .Include(l => l.Banks)
                .Include(l => l.LoanTypes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loanProduct == null)
            {
                return NotFound();
            }

            return View(loanProduct);
        }

        // POST: LoanProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanProduct = await _context.LoanProduct.FindAsync(id);
            _context.LoanProduct.Remove(loanProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanProductExists(int id)
        {
            return _context.LoanProduct.Any(e => e.Id == id);
        }
    }
}
