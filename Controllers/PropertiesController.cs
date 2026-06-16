using LeaseManagement.API.Data;
using LeaseManagement.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LeaseManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProperties()
        {
            var properties = await _context.Properties.ToListAsync();
            return Ok(properties);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(Property property)
        {
            _context.Properties.Add(property);
            await _context.SaveChangesAsync();

            return Ok(property);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, Property property)
        {
            var existingProperty = await _context.Properties.FindAsync(id);

            if (existingProperty == null)
            {
                return NotFound();
            }

            existingProperty.Name = property.Name;
            existingProperty.Type = property.Type;
            existingProperty.Location = property.Location;
            existingProperty.Status = property.Status;

            await _context.SaveChangesAsync();

            return Ok(existingProperty);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}