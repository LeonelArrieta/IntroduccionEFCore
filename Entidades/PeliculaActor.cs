namespace IntroduccionEFCore.Entidades
{
    public class PeliculaActor
    {
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; } = null!;
        public int ActorId { get; set; }
        public Actor Actor { get; set; } = null!;
        public string Personaje { get; set; } = null!;
        //variable para dar orden a la entrada de datos de actores
        public int Orden { get; set; }
    }
}
