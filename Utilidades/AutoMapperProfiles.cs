using AutoMapper;
using IntroduccionEFCore.DTOs;
using IntroduccionEFCore.Entidades;

namespace IntroduccionEFCore.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<ActorCreacionDTO, Actor>();
            CreateMap<PeliculaCreacionDTO, Pelicula>()
                .ForMember(ent => ent.Generos, 
                //mapeo de genero a enteros. es una proyeccion (?. el id se transforma en genero
                //a partir de cada valor del listado de enteros de la clase PeliculasCreacionDTO se va a crear un genero en donde la propiedad se coloca como el campo id
                dto => dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));

            CreateMap<PeliculaActorCreacionDTO, PeliculaActor>();
            CreateMap<ComentarioCreacionDTO,Comentario>();

        }
    }
}
