using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarDealerManager.Data;
using CarDealerManager.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarDealerManager.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly CarDealerManagerCREDContext _context;

        public CarsController(CarDealerManagerCREDContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            ErrorMessageHandler.ISThereError = "false";
            var carDealerManagerCREDContext = _context.Car.Include(c => c.supplier);
            return View(await carDealerManagerCREDContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["SupplierFK"] = new SelectList(_context.Supplier, "Id", "SupplierName");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CarBrandName,CarModel,CarYear,Fuel,Transmission,Color,InStock,SupplierFK")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierFK"] = new SelectList(_context.Supplier, "Id", "SupplierName", car.SupplierFK);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["SupplierFK"] = new SelectList(_context.Supplier, "Id", "SupplierName", car.SupplierFK);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CarBrandName,CarModel,CarYear,Fuel,Transmission,Color,InStock,SupplierFK")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            ViewData["SupplierFK"] = new SelectList(_context.Supplier, "Id", "SupplierName", car.SupplierFK);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(c => c.supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            ErrorMessageHandler.ErrorMessage = "No Error Message given";
            try
            {
                await _context.SaveChangesAsync();
            }catch (Exception ex){
                ErrorMessageHandler.ErrorMessage = ex.Message;
                ErrorMessageHandler.CustomErrorMessagePart1 = "If data is not deleted we recomend you to first delete this car from store";
                ErrorMessageHandler.CustomErrorMessagePart2 = "If error continue afterwards contact your IT support!";
                ErrorMessageHandler.ISThereError = "true";
            }
            if (ErrorMessageHandler.ISThereError == "true")
            {
                return RedirectToAction(nameof(Delete));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
