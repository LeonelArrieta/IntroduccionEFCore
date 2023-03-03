namespace IntroduccionEFCore.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }

        //Hashset no se recomienda para entidades q necesitan ser ordenadas       
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();

        //esta configuracion entre generopelicula se salta la tabla intermedia ya q no se especifica en codigo
        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();

        //utilizacion de la entidad intermedia peliculasactores
        public List<PeliculaActor>PeliculasActores { get; set; } = new List<PeliculaActor>();
    }
}
