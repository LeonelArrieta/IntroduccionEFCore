using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/generos")]
    public class GeneroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GeneroController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> Get()
        {
            return await _context.Generos.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreacionDTO generoCreacion)
        {
            //Implementacion de automapper
            var genero = _mapper.Map<Genero>(generoCreacion);
            _context.Add(genero);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpPost("varios")]
        public async Task<ActionResult> Post(GeneroCreacionDTO[] generoCreacionDTOs)
        {
            var generos = _mapper.Map<Genero[]>(generoCreacionDTOs);
            _context.AddRange(generos);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
