using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IAPL_Assignment.Data;

namespace IAPL_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
         dbsIAPLAssignmentContext _context = new dbsIAPLAssignmentContext();

       

        // GET: api/Measurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurements()
        {
            return await _context.Measurements.ToListAsync();
        }

        // GET: api/Measurements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return NotFound();
            }

            return measurement;
        }

        // PUT: api/Measurements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasurement(int id, Measurement measurement)
        {
            if (id != measurement.Measurementid)
            {
                return BadRequest();
            }

            _context.Entry(measurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
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

        // POST: api/Measurements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Measurement>> PostMeasurement(Measurement measurement)
        {
            _context.Measurements.Add(measurement);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MeasurementExists(measurement.Measurementid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMeasurement", new { id = measurement.Measurementid }, measurement);
        }

        // DELETE: api/Measurements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return NotFound();
            }

            _context.Measurements.Remove(measurement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurements.Any(e => e.Measurementid == id);
        }
    }
}
