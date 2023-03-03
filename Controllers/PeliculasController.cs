using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroduccionEFCore.Controllers
{
    [ApiController]
    [Route("api/peliculas")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PeliculasController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Post(PeliculaCreacionDTO peliculaCreacionDTO)
        {
            var pelicula = _mapper.Map<Pelicula>(peliculaCreacionDTO);

            if(pelicula.Generos is not null)
            {
                foreach(var genero in pelicula.Generos)
                {
                    //El context le da seguimiento a los registros, genero tiene un registro sin modificacion. No se crea un nuevo genero
                    //esto se hace porq en esta relacion muchos a muchos no se creo la tabla intermedia 
                    _context.Entry(genero).State=EntityState.Unchanged;

                }
            }

            if(pelicula.PeliculasActores is not null)
            {
                for(int i = 0; i < pelicula.PeliculasActores.Count; i++)
                {
                    //damos orden a la entrada de datos de los actores
                    pelicula.PeliculasActores[i].Orden = i + 1;
                }
            }
            _context.Add(pelicula);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
