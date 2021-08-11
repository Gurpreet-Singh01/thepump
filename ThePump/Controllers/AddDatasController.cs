using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThePump.Data;
using ThePump.Models;

namespace ThePump.Controllers
{
    [Authorize(Roles="Administrator")]
    public class AddDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddDatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AddData.Include(a => a.Goal);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AddDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addData = await _context.AddData
                .Include(a => a.Goal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addData == null)
            {
                return NotFound();
            }

            return View(addData);
        }

        // GET: AddDatas/Create
        public IActionResult Create()
        {
            ViewData["GoalId"] = new SelectList(_context.Goal, "Id", "FitnessGoal");
            return View();
        }

        // POST: AddDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CurrentBodyWeight,RequiredBodyWeight,TypeOfExercise,GoalId")] AddData addData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GoalId"] = new SelectList(_context.Goal, "Id", "FitnessGoal", addData.GoalId);
            return View(addData);
        }

        // GET: AddDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addData = await _context.AddData.FindAsync(id);
            if (addData == null)
            {
                return NotFound();
            }
            ViewData["GoalId"] = new SelectList(_context.Goal, "Id", "FitnessGoal", addData.GoalId);
            return View(addData);
        }

        // POST: AddDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CurrentBodyWeight,RequiredBodyWeight,TypeOfExercise,GoalId")] AddData addData)
        {
            if (id != addData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddDataExists(addData.Id))
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
            ViewData["GoalId"] = new SelectList(_context.Goal, "Id", "FitnessGoal", addData.GoalId);
            return View(addData);
        }

        // GET: AddDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addData = await _context.AddData
                .Include(a => a.Goal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addData == null)
            {
                return NotFound();
            }

            return View(addData);
        }

        // POST: AddDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addData = await _context.AddData.FindAsync(id);
            _context.AddData.Remove(addData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddDataExists(int id)
        {
            return _context.AddData.Any(e => e.Id == id);
        }
    }
}
