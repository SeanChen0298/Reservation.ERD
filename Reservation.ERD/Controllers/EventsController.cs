using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservation.ERD.Data;
using Reservation.ERD.Model;
using Reservation.ERD.Service;

namespace Reservation.ERD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ReservationContext _context;
        private readonly EventService eventService;

        public EventsController(ReservationContext context, EventService eventService)
        {
            _context = context;
            eventService = eventService;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.Include(e => e.ResourceEvents).ThenInclude(re => re.ResourceEventAttendees).ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(Guid id)
        {
            var @event = await _context.Events.Include(e => e.ResourceEvents)
                            .ThenInclude(re => re.ResourceEventAttendees)
                        .FirstOrDefaultAsync(e => e.Id == id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(Guid id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            var currentUtc = DateTime.UtcNow;
            var existingEvents = await _context.Events
                                .Where(e => e.EndAt >= currentUtc)
                                .ToListAsync();

            foreach ( var existingEvent in existingEvents )
            {
                if(eventService.CheckOverlap(existingEvent, @event))
                {
                    return Forbid();
                }
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            var currentUtc = DateTime.UtcNow;
            var existingEvents = await _context.Events
                                .Where(e => e.EndAt >= currentUtc)
                                .ToListAsync();

            foreach (var existingEvent in existingEvents)
            {
                if (eventService.CheckOverlap(existingEvent, @event))
                {
                    return Forbid();
                }
            }

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(Guid id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
