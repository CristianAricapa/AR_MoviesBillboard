using UnityEngine;
using UnityEngine.UI;

public class DataBaseManager : MonoBehaviour
{


    public General.Pelicula pelicula;
    public General.Actor[] actor;
    public General.Relacion data;

    //[Header("Orientation")]
    //public GameObject landScape;
    //public GameObject portrait;

    public RegistroActor registro;
    public RegistroMovie registroMovie;
    public int _currentActor = 0;
    

    public struct RegistroActor
    {
        public General.Actor actor;
        public string papel;
    }

    public struct RegistroMovie
    {
        public General.Pelicula movie;
    }



    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadData(string name)
    {


        data = JsonUtility.FromJson<General.Relacion>(FileManager.LoadJSONFile(name, Enums.TypeOfFile.Relation));

        pelicula = JsonUtility.FromJson<General.Pelicula>(FileManager.LoadJSONFile(data.id_pelicula.ToString(), Enums.TypeOfFile.Movies));

        actor = new General.Actor[data.reparto.Length];

        for (int i = 0; i < data.reparto.Length; i++)
        {
            actor[i] = JsonUtility.FromJson<General.Actor>(FileManager.LoadJSONFile(data.reparto[i].id_actor.ToString(), Enums.TypeOfFile.Actors));
        }

    }

    public void GetActor(int indice)
    {
        _currentActor = indice;
        registro.papel = data.reparto[indice].papel;

        for (int i = 0; i < actor.Length; i++)
        {
            if (actor[i].id_actor == data.reparto[_currentActor].id_actor)
            {
                registro.actor = actor[i];
                break;
            }
        }

    }

    public void NextActor()
    {
        int nextActor = _currentActor + 1;

        if (nextActor < actor.Length)
            GetActor(nextActor);
        else
            GetActor(0);
    }
    public void PrevActor()
    {
        int nextActor = _currentActor - 1;

        if (nextActor >= 0)
            GetActor(nextActor);
        else
            GetActor(actor.Length - 1);

    }


}
