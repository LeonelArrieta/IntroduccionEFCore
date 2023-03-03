using IntroduccionEFCore.Entidades;
using IntroduccionEFCore.Entidades.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IntroduccionEFCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //permite implementar configuraciones desde el dll , las q implementan IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Registros del seeding echos en la configuracion inicial
            SeedingInicial.Seed(modelBuilder);
           


        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //convencion para q los string sean de 150 max
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }
        public DbSet<Genero>Generos=>Set<Genero>();
        public DbSet<Actor> Actores =>Set<Actor>();
        public DbSet<Pelicula> Peliculas => Set<Pelicula>();
        public DbSet<Comentario> Comentarios => Set<Comentario>();

        //Creacion de la tabla intermedia relacion muchos a muchos peliculaactore
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();

    }
}
