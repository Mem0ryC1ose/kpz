using AutoMapper;
using Lab4WebApi.Models.DTO;
using Lab4WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TariffsController : ControllerBase
    {
        private readonly TableContext _context;
        private readonly IMapper _mapper;

        public TariffsController(TableContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TariffCreateDTO>>> GetTariffs()
        {
            var tariffs = await _context.Tariffs.ToListAsync();
            return Ok(tariffs);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Tariff>> GetTariff(int id)
        {
            var tariff = await _context.Tariffs.FindAsync(id);

            if (tariff == null)
            {
                return NotFound();
            }

            return Ok(tariff);
        }

        [HttpPost]
        public async Task<ActionResult<Tariff>> PostTariffe(TariffCreateDTO tariffcdto)
        {
            var tariff = _mapper.Map<Tariff>(tariffcdto);
            _context.Tariffs.Add(tariff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTariff", new { id = tariff.Id }, tariff);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTariff(int id, TariffCreateDTO tariffudto)
        {
            var existingTariff = await _context.Tariffs.FindAsync(id);
            if (existingTariff == null)
            {
                return NotFound();
            }

            existingTariff.Name = tariffudto.Name;
            existingTariff.ServiceId = tariffudto.ServiceId;
            existingTariff.Price = tariffudto.Price;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tariffs.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteTariff(int id)
        {
            var tariff = await _context.Tariffs.FindAsync(id);
            if (tariff == null)
            {
                return NotFound();
            }

            _context.Tariffs.Remove(tariff);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
