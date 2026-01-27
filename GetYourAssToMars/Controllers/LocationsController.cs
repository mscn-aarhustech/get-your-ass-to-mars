using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using GetYourAssToMars.Data;
using GetYourAssToMars.Models;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public LocationsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Location>>> GetLocations() 
        => await _context.Locations.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Location>> PostLocation(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLocations), new { id = location.Id }, location);
    }

    // This endpoint takes a SQL quey - any query - as an argument, allowing users total freedom. 
    // What might be the problem with that?
    [HttpPost("query")]
    public async Task<ActionResult<IEnumerable<Location>>> ExecuteRawQuery([FromBody] string query)
    {
        try
        {
            var results = await _context.Locations
                .FromSqlRaw(query)
                .ToListAsync();

            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}