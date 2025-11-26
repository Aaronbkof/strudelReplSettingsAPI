using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrudelSettingsAPI.Models;

namespace StrudelSettingsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class strudelSettingsController : ControllerBase
    {
        private readonly strudelSettingsDbContext _context;

        public strudelSettingsController(strudelSettingsDbContext context)
        {
            _context = context;
        }

        // GET: api/strudelSettings/GetSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Settings>>> GetSettings()
        {
            return await _context.Settings.ToListAsync();
        }

        // GET: api/strudelSettings/GetSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Settings>> GetSettings(int id)
        {
            var settings = await _context.Settings.FindAsync(id);

            if (settings == null)
            {
                return NotFound();
            }

            return settings;
        }

        // GET: api/strudelSettings/GetSavedPreset
        // this endpoint is for getting the most recent saved preset/setting
        [HttpGet]
        public async Task<ActionResult<Settings>> GetSavedPreset()
        {
            // retrieve the most recently saved preset
            var preset = await _context.Settings
                .OrderByDescending(x => x.SavedAt)
                .FirstOrDefaultAsync();

            // if there is no saved presets present in DB return error
            if (preset == null)
            {
                return NotFound();
            }

            return preset;
        }

        // PUT: api/strudelSettings/PutSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSettings(int id, Settings settings)
        {
            if (id != settings.Id)
            {
                return BadRequest();
            }

            _context.Entry(settings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SettingsExists(id))
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

        // POST: api/strudelSettings/SavePreset
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Settings>> SavePreset(Settings settings)
        {
            _context.Settings.Add(settings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSettings", new { id = settings.Id }, settings);
        }

        // DELETE: api/strudelSettings/DeleteSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSettings(int id)
        {
            var settings = await _context.Settings.FindAsync(id);
            if (settings == null)
            {
                return NotFound();
            }

            _context.Settings.Remove(settings);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SettingsExists(int id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}