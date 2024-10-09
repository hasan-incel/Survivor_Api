using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor_Api.Contexts;
using Survivor_Api.Entities;

[Route("api/[controller]")]
[ApiController]
public class CompetitorController : ControllerBase
{
    private readonly SurvivorContext _context;

    public CompetitorController(SurvivorContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Competitor>> GetAll()
    {
        return Ok(_context.Competitors.Where(c => !c.IsDeleted).ToList());
    }

    [HttpGet("{id}")]
    public ActionResult<Competitor> GetById(int id)
    {
        var competitor = _context.Competitors.Find(id);
        if (competitor == null || competitor.IsDeleted)
        {
            return NotFound();
        }
        return Ok(competitor);
    }

    [HttpGet("categories/{categoryId}")]
    public ActionResult<IEnumerable<Competitor>> GetByCategoryId(int categoryId)
    {
        return Ok(_context.Competitors.Where(c => c.CategoryId == categoryId && !c.IsDeleted).ToList());
    }

    [HttpPost]
    public ActionResult<Competitor> Create([FromBody] Competitor competitor)
    {
        _context.Competitors.Add(competitor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = competitor.Id }, competitor);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Competitor competitor)
    {
        if (id != competitor.Id)
        {
            return BadRequest();
        }

        _context.Entry(competitor).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var competitor = _context.Competitors.Find(id);
        if (competitor == null || competitor.IsDeleted)
        {
            return NotFound();
        }

        competitor.IsDeleted = true;
        _context.SaveChanges();
        return NoContent();
    }
}
