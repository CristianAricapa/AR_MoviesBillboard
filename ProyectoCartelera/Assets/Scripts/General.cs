public class General
{
    [System.Serializable]
    public class Pelicula
    {
        public int id_pelicula;
        public string titulo;
        public int year;
        public string director;
        public string sinopsis;
        public Enums.Paises id_nacion;
    }

    [System.Serializable]
    public class Actor
    {
        public int id_actor;
        public string nombre;
        public string biografia;
        public Enums.Paises id_nacion;
        public Enums.Sexo sexo;

    }

    [System.Serializable]
    public class Relacion
    {
        public int id_reparto;
        public int id_pelicula;
        public Reparto[] reparto;
    }

    [System.Serializable]
    public class Reparto
    {
        public int id_actor;
        public string papel;
    }

    public enum EnumMovies { TRANSCENDENCE, BAYWATCH, NATIONAL_TREASURE, MAX_MOVIES };
}

public static class Constants
{
    //public const string DIRECTORY_ACTORS = "/Resources/Files/Actors/";
    //public const string DIRECTORY_MOVIES = "/Resources/Files/Movies/";   
    //public const string DIRECTORY_RELATIONS = "/Resources/Files/Relation/";

    // El orden debe estar directamente relacionado
    public static string[] DIRECTORIES = { "/Resources/Files/Actors/", "/Resources/Files/Movies/", "/Resources/Files/Relation/" };

    public const string JSON_EXTENSION = ".json";
}

public class Enums
{
    public enum TypeOfFile { Actors, Movies, Relation };
    public enum Sexo { Actor, Actriz }
    public enum Paises
    {
        EEUU = 1,
        Londres,
        India,
        Alemania
    }
}

