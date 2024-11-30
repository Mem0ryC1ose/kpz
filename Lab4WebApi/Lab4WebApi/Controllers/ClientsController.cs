using AutoMapper;
using Lab4WebApi.Models;
using Lab4WebApi.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly TableContext _context;
        private readonly IMapper _mapper;

        public ClientsController(TableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            var clients = await _context.Clients.ToListAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientCreateDTO clientcdto)
        {
            var client = _mapper.Map<Client>(clientcdto);
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientCreateDTO clientcdto)
        {
            var existingClient = await _context.Clients.FindAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            existingClient.Name = clientcdto.Name;
            existingClient.PhoneNumber = clientcdto.PhoneNumber;
            existingClient.Address = clientcdto.Address;
            existingClient.Email = clientcdto.Email;
            existingClient.RegistrationDate = clientcdto.RegistrationDate;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Clients.Any(e => e.Id == id))
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
