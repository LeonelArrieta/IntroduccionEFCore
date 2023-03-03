using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/peliculas/{peliculaId:int}/comentarios")]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ComentariosController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post(int peliculaId, ComentarioCreacionDTO comentarioCreacionDTO)
        {
            var comentario = _mapper.Map<Comentario>(comentarioCreacionDTO);
            comentario.PeliculaId=peliculaId;
            _context.Add(comentario);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
