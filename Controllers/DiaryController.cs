using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TApi.Models;

namespace TApi.Controllers
{
    [ApiController]
    [Route("api/diary")]
    public class DiaryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public DiaryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get()
        {
            var notes = await _db.User.ToListAsync();

            return Ok(notes);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User note)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/

            _db.User.Add(note);
            await _db.SaveChangesAsync();

            return Ok(note);
        }
    }
}
