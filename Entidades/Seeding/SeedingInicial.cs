using Microsoft.EntityFrameworkCore;

namespace IntroduccionEFCore.Entidades.Seeding
{
    public class SeedingInicial
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var samuelLJackson = new Actor()
            {
                Id = 4,
                Nombre = "Samuel L Jackson",
                FechaNacimiento = new DateTime(1948, 12, 21),
                Fortuna = 15000
            }; 
            var RobertDowneyJunior = new Actor()
            {
                Id = 5,
                Nombre = "Robert Downey Junior",
                FechaNacimiento = new DateTime(1965, 4, 4),
                Fortuna = 18000
            };
            //Utilizacion del hasdata para insertar los registros
            modelBuilder.Entity<Actor>().HasData(samuelLJackson, RobertDowneyJunior);

            var avengers = new Pelicula
            {
                Id = 3,
                Titulo = "Avengers Endgame",
                FechaEstreno = new DateTime(2019, 4, 22)

            };
            var spidermanNWH = new Pelicula
            {
                Id = 4,
                Titulo = "Spider-Man: No Way Home",
                FechaEstreno = new DateTime(2021, 12, 13)

            };
            var spiderManSpiderVerse2 = new Pelicula
            {
                Id = 5,
                Titulo = "Spider-Man: Across the Spider-Verse (Part One)",
                FechaEstreno = new DateTime(2022, 10, 7)

            };
            modelBuilder.Entity<Pelicula>().HasData(avengers, spidermanNWH, spiderManSpiderVerse2);

            var comentarioAvengers = new Comentario()
            {
                Id = 2,
                Recomendar = true,
                Contenido = "Muy buena!!",
                PeliculaId = avengers.Id,
            };
            var comentariospiderManNWH = new Comentario()
            {
                Id = 3,
                Recomendar = true,
                Contenido = "Muy buena la pelicula!!",
                PeliculaId = spidermanNWH.Id,
            };
            var comentariospiderManSpiderVerse2 = new Comentario()
            {
                Id = 4,
                Recomendar = false,
                Contenido = "No me gusto! :P",
                PeliculaId = spiderManSpiderVerse2.Id,
            };
            modelBuilder.Entity<Comentario>().HasData(comentarioAvengers, comentariospiderManNWH, comentariospiderManSpiderVerse2);

            //Muchos a muchos con salto, no se usa la entidad intermedia

            var tablaGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosId";
            var peliculaIdPropiedad = "PeliculasId";
            var cienciaFiccion = 5;
            var animacion = 6;

            modelBuilder.Entity(tablaGeneroPelicula).HasData(
                new Dictionary<string, object> 
                { 
                   [generoIdPropiedad] = cienciaFiccion,
                   [peliculaIdPropiedad]=avengers.Id
                },
                new Dictionary<string, object>
                {
                   [generoIdPropiedad] = cienciaFiccion,
                   [peliculaIdPropiedad] = spidermanNWH.Id
                },
                new Dictionary<string, object>
                {
                   [generoIdPropiedad] = animacion,
                   [peliculaIdPropiedad] = spiderManSpiderVerse2.Id
                }
                );

            //Muchos a muchoas sin salto

            var samuelLJacksonSpiderManNWH = new PeliculaActor
            {
                ActorId = samuelLJackson.Id,
                PeliculaId = spidermanNWH.Id,
                Orden = 1,
                Personaje = "Nick Fury"
            };
            var samuelLJacksonAvengers = new PeliculaActor
            {
                ActorId = samuelLJackson.Id,
                PeliculaId = avengers.Id,
                Orden = 2,
                Personaje = "Nick Fury"
            };
            var robertDowneyJuniorAvengers = new PeliculaActor
            {
                ActorId = RobertDowneyJunior.Id,
                PeliculaId = avengers.Id,
                Orden = 1,
                Personaje = "Iron Man"
            };
            modelBuilder.Entity<PeliculaActor>().HasData(samuelLJacksonSpiderManNWH,samuelLJacksonAvengers,robertDowneyJuniorAvengers);
        }
    }
}
