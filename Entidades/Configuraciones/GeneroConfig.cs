using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionEFCore.Entidades.Configuraciones
{
    public class GeneroConfig : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            //Configuracion de la base de datos para q inicie con los campos especificados
            var cienciaFiccion = new Genero { Id = 5, Nombre = "Ciencia Ficción" };
            var animacion = new Genero { Id = 6, Nombre = "Animación" };
            builder.HasData(cienciaFiccion, animacion);

        }
    }
}
