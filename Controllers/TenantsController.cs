using LeaseManagement.API.Data;
using LeaseManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaseManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TenantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTenants()
        {
            return Ok(await _context.Tenants.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTenant(Tenant tenant)
        {
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();
            return Ok(tenant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenant(int id, Tenant tenant)
        {
            var existing = await _context.Tenants.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.Name = tenant.Name;
            existing.Email = tenant.Email;
            existing.Phone = tenant.Phone;
            existing.Status = tenant.Status;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenant(int id)
        {
            var tenant = await _context.Tenants.FindAsync(id);

            if (tenant == null)
                return NotFound();

            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}