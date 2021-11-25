using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMAppBackendAPI.Models;

namespace SIMAppBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageInfoesController : ControllerBase
    {
        private readonly lab3Context _context;

        public StorageInfoesController(lab3Context context)
        {
            _context = context;
        }

        // GET: api/StorageInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageInfo>>> GetStorageInfos()
        {
            return await _context.StorageInfos.ToListAsync();
        }

        // GET: api/StorageInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StorageInfo>> GetStorageInfo(int id)
        {
            var storageInfo = await _context.StorageInfos.FindAsync(id);

            if (storageInfo == null)
            {
                return NotFound();
            }

            return storageInfo;
        }

        // PUT: api/StorageInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorageInfo(int id, StorageInfo storageInfo)
        {
            if (id != storageInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(storageInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageInfoExists(id))
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

        // POST: api/StorageInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StorageInfo>> PostStorageInfo(StorageInfo storageInfo)
        {
            _context.StorageInfos.Add(storageInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorageInfo", new { id = storageInfo.Id }, storageInfo);
        }

        // DELETE: api/StorageInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorageInfo(int id)
        {
            var storageInfo = await _context.StorageInfos.FindAsync(id);
            if (storageInfo == null)
            {
                return NotFound();
            }

            _context.StorageInfos.Remove(storageInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StorageInfoExists(int id)
        {
            return _context.StorageInfos.Any(e => e.Id == id);
        }
    }
}
