using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransectionTest1.Models;

namespace TransectionTest1.Controllers
{
    public class Transaction23csController : Controller
    {
        private readonly TranDbContext _context;

        public Transaction23csController(TranDbContext context)
        {
            _context = context;
        }

        // GET: Transaction23cs
        public async Task<IActionResult> Index()
        {
              return _context.TransactionsGP != null ? 
                          View(await _context.TransactionsGP.ToListAsync()) :
                          Problem("Entity set 'TranDbContext.TransactionsGP'  is null.");
        }

      

        // GET: Transaction23cs/Create
        public IActionResult AddOrEdit(int id=0)
        {
            if(id == 0) 
            {
                return View(new Transaction23cs());
            }
            else 
            {
                return View(_context.TransactionsGP.Find(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")] Transaction23cs transaction23cs)
        {
            if (ModelState.IsValid)
            {
                if (transaction23cs.TransactionId == 0)
                {
                    transaction23cs.Date = DateTime.Now;
                    _context.Add(transaction23cs);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
               else
                {
                    _context.Update(transaction23cs);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                    
                
               
            }
            return View(transaction23cs);
        }

        // GET: Transaction23cs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransactionsGP == null)
            {
                return NotFound();
            }

            var transaction23cs = await _context.TransactionsGP
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction23cs == null)
            {
                return NotFound();
            }

            return View(transaction23cs);
        }

        // POST: Transaction23cs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransactionsGP == null)
            {
                return Problem("Entity set 'TranDbContext.TransactionsGP'  is null.");
            }
            var transaction23cs = await _context.TransactionsGP.FindAsync(id);
            if (transaction23cs != null)
            {
                _context.TransactionsGP.Remove(transaction23cs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AboutMe(int? id) 
        { 
            return View();
        }

    }
}
