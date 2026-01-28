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

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Location>>> GetLocation(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        
        if (location == null)
        {
            return NotFound();
        } 
        else
        {
            return Ok(location);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Location>> PostLocation(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLocations), new { id = location.Id }, location);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLocation(int id, Location location)
    {
        if (id != location.Id)
        {
            return BadRequest("ID mismatch");
        }

        _context.Entry(location).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Locations.Any(e => e.Id == id))
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

    [HttpDelete]
    public async Task<ActionResult<Location>> DeleteLocation(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        
        if (location == null)
        {
            return NotFound();
        }

        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();

        return NoContent();
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