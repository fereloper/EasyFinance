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
    public class BanksController : Controller
    {
        private readonly BankContext _context;

        public BanksController(BankContext context)
        {
            _context = context;
        }

        // GET: Banks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banks.ToListAsync());
        }

        // GET: Banks/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Banks());
            else
                return View(_context.Banks.Find(id));
        }

        // POST: Banks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,LogoImage,CreatedAt,UpdatedAt")] Banks banks)
        {
            if (ModelState.IsValid)
            {
                if (banks.Id == 0)
                    _context.Add(banks);
                else
                    _context.Update(banks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banks);
        }

        // GET: Banks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var bank = await _context.Banks.FindAsync(id);

            _context.Banks.Remove(bank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
