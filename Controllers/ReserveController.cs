using api_net.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private static List<Reserve> reserves = new List<Reserve>
        {

        };
        private readonly DataContext _context;

        public ReserveController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reserve>>> Get()
        {
            return Ok(await _context.Reserves.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reserve>> Get(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);
            return reserve == null ? (ActionResult<Reserve>)BadRequest("Reserve Not Found.") : (ActionResult<Reserve>)Ok(reserve);
        }

        [HttpPost]
        public async Task<ActionResult<List<Reserve>>> AddReserve(Reserve reserve)
        {
            _context.Reserves.Add(reserve);
            await _context.SaveChangesAsync();
            return Ok(await _context.Reserves.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Reserve>>> UpdateReserve(Reserve req)
        {
            var reserve = await _context.Reserves.FindAsync(req.id);
            if (reserve == null)
                return BadRequest("Reserve Not Found.");
            reserve.email = req.email;
            reserve.dateIn = req.dateIn;
            reserve.dateOut = req.dateOut;
            reserve.allDates = req.allDates;
            reserve.animals = req.animals;
            reserve.message = req.message;
            reserve.roomName = req.roomName;
            reserve.animals = req.animals;
            reserve.phone = req.phone;
            reserve.personsCount = req.personsCount;
            await _context.SaveChangesAsync();
            return Ok(await _context.Reserves.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Reserve>> Delete(int id)
        {
            var reserve = await _context.Reserves.FindAsync(id);
            if (reserve == null)
                return BadRequest("Reserve Not Found.");
            _context.Reserves.Remove(reserve);
            await _context.SaveChangesAsync();
            return Ok(await _context.Reserves.ToListAsync());
        }
    }
}
