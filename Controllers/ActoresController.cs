using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/actores")]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActoresController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await _context.Actores.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await _context.Actores.FirstOrDefaultAsync(a=>a.Id==id);
            if(actor is null)
            {
                return NotFound();
            }
            return actor;
        }
        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string nombre)
        {
            //version 1 de buscar por nombre
            return await _context.Actores.Where(a => a.Nombre == nombre).ToListAsync();
        }
        [HttpGet("nombre/v2")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetV2(string nombre)
        {
            //version 2 Contiene
            return await _context.Actores.Where(a => a.Nombre.Contains(nombre)).ToListAsync();
        }
        [HttpGet("fechaNacimiento/rango")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get (DateTime inicio, DateTime fin)
        {
            return await _context.Actores
                .Where(a => a.FechaNacimiento >= inicio && a.FechaNacimiento <= fin)
                .ToListAsync();

        }
        [HttpPost]
        public async Task<ActionResult> Post (ActorCreacionDTO actorCreacionDTO)
        {
            var actor = _mapper.Map<Actor>(actorCreacionDTO);
            _context.Add(actor);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
