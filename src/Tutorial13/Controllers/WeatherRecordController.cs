using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tutorial13;
using Tutorial13.DTOs;
using Tutorial13.Entities;

namespace Tutorial13.Controllers
{
    [Route("api/weathers")]
    [ApiController]
    public class WeatherRecordController(WeatherBookContext context) : ControllerBase
    {
        // GET: api/WeatherRecord
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortWeatherRecordDto>>> GetWeatherRecords(
            CancellationToken cancellationToken)
        {
            var records = await context.WeatherRecords.Include(wr => wr.City)
                .Include(wr => wr.WeatherType).ToListAsync(cancellationToken);
            return Ok(records.Select(r => new ShortWeatherRecordDto(r)));
        }

        // GET: api/WeatherRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LongWeatherRecordDto>> GetWeatherRecord(int id)
        {
            var weatherRecord = await context.WeatherRecords.Include(wr => wr.WeatherType)
                .Include(wr => wr.City).ThenInclude(c => c.Country)
                .FirstOrDefaultAsync(wr => wr.Id == id);

            if (weatherRecord == null)
            {
                return NotFound();
            }
            
            return new LongWeatherRecordDto(weatherRecord);
        }

        // PUT: api/WeatherRecord/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherRecord(int id, WeatherRecord weatherRecord)
        {
            if (id != weatherRecord.Id)
            {
                return BadRequest();
            }

            context.Entry(weatherRecord).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherRecord
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherRecord>> PostWeatherRecord(WeatherRecord weatherRecord)
        {
            context.WeatherRecords.Add(weatherRecord);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherRecord", new { id = weatherRecord.Id }, weatherRecord);
        }

        // DELETE: api/WeatherRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherRecord(int id)
        {
            var weatherRecord = await context.WeatherRecords.FindAsync(id);
            if (weatherRecord == null)
            {
                return NotFound();
            }

            context.WeatherRecords.Remove(weatherRecord);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherRecordExists(int id)
        {
            return context.WeatherRecords.Any(e => e.Id == id);
        }
    }
}