using LeaseManagement.API.Data;
using LeaseManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaseManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeasesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeases()
        {
            return Ok(await _context.Leases.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateLease(Lease lease)
        {
            _context.Leases.Add(lease);
            await _context.SaveChangesAsync();

            return Ok(lease);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLease(int id, Lease lease)
        {
            var existing = await _context.Leases.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.LeaseNo = lease.LeaseNo;
            existing.Property = lease.Property;
            existing.Tenant = lease.Tenant;
            existing.Rent = lease.Rent;
            existing.Status = lease.Status;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLease(int id)
        {
            var lease = await _context.Leases.FindAsync(id);

            if (lease == null)
                return NotFound();

            _context.Leases.Remove(lease);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}