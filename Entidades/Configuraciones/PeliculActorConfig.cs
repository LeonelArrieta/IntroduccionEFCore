using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroduccionEFCore.Entidades.Configuraciones
{
    public class PeliculActorConfig : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            //llave primaria compuesta
            builder.HasKey(pa => new { pa.ActorId, pa.PeliculaId });
        }
    }
}
