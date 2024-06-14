using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tutorial13;
using Tutorial13.Entities;

namespace Tutorial13.Controllers
{
    public class RecordWeatherController : Controller
    {
        private readonly WeatherBookContext _context;

        public RecordWeatherController(WeatherBookContext context)
        {
            _context = context;
        }

        // GET: RecordWeather
        public async Task<IActionResult> Index()
        {
            var weatherBookContext = _context.WeatherRecords.Include(w => w.City).Include(w => w.WeatherType);
            return View(await weatherBookContext.ToListAsync());
        }

        // GET: RecordWeather/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherRecord = await _context.WeatherRecords
                .Include(w => w.City)
                .Include(w => w.WeatherType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherRecord == null)
            {
                return NotFound();
            }

            return View(weatherRecord);
        }

        // GET: RecordWeather/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id");
            ViewData["WeatherTypeId"] = new SelectList(_context.WeatherTypes, "Id", "Id");
            return View();
        }

        // POST: RecordWeather/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityId,WeatherTypeId,Temperature,DateHappened,Description")] WeatherRecord weatherRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", weatherRecord.CityId);
            ViewData["WeatherTypeId"] = new SelectList(_context.WeatherTypes, "Id", "Id", weatherRecord.WeatherTypeId);
            return View(weatherRecord);
        }

        // GET: RecordWeather/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherRecord = await _context.WeatherRecords.FindAsync(id);
            if (weatherRecord == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", weatherRecord.CityId);
            ViewData["WeatherTypeId"] = new SelectList(_context.WeatherTypes, "Id", "Id", weatherRecord.WeatherTypeId);
            return View(weatherRecord);
        }

        // POST: RecordWeather/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CityId,WeatherTypeId,Temperature,DateHappened,Description")] WeatherRecord weatherRecord)
        {
            if (id != weatherRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherRecordExists(weatherRecord.Id))
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
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Id", weatherRecord.CityId);
            ViewData["WeatherTypeId"] = new SelectList(_context.WeatherTypes, "Id", "Id", weatherRecord.WeatherTypeId);
            return View(weatherRecord);
        }

        // GET: RecordWeather/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherRecord = await _context.WeatherRecords
                .Include(w => w.City)
                .Include(w => w.WeatherType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherRecord == null)
            {
                return NotFound();
            }

            return View(weatherRecord);
        }

        // POST: RecordWeather/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherRecord = await _context.WeatherRecords.FindAsync(id);
            if (weatherRecord != null)
            {
                _context.WeatherRecords.Remove(weatherRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherRecordExists(int id)
        {
            return _context.WeatherRecords.Any(e => e.Id == id);
        }
    }
}
