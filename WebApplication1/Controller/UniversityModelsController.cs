using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityModelsController : ControllerBase
    {
        private readonly StudentContext _context;

        public UniversityModelsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/UniversityModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversityModel>>> GetUniversityModel()
        {
          if (_context.UniversityModel == null)
          {
              return NotFound();
          }
            return await _context.UniversityModel.ToListAsync();
        }

        // GET: api/UniversityModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityModel>> GetUniversityModel(int id)
        {
          if (_context.UniversityModel == null)
          {
              return NotFound();
          }
            var universityModel = await _context.UniversityModel.FindAsync(id);

            if (universityModel == null)
            {
                return NotFound();
            }

            return universityModel;
        }

        // PUT: api/UniversityModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversityModel(int id, UniversityModel universityModel)
        {
            if (id != universityModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(universityModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityModelExists(id))
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

        // POST: api/UniversityModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UniversityModel>> PostUniversityModel(UniversityModel universityModel)
        {
          if (_context.UniversityModel == null)
          {
              return Problem("Entity set 'StudentContext.UniversityModel'  is null.");
          }
            _context.UniversityModel.Add(universityModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUniversityModel", new { id = universityModel.Id }, universityModel);
        }

        // DELETE: api/UniversityModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversityModel(int id)
        {
            if (_context.UniversityModel == null)
            {
                return NotFound();
            }
            var universityModel = await _context.UniversityModel.FindAsync(id);
            if (universityModel == null)
            {
                return NotFound();
            }

            _context.UniversityModel.Remove(universityModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UniversityModelExists(int id)
        {
            return (_context.UniversityModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
