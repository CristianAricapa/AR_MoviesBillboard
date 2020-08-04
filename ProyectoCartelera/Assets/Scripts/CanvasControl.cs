using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{

    [Header("Landscape")]
    #region LandscapeText
    //public Text titulo;
    public Text nombreActor;
    public Text papelActor;
    public Text sexoActor;
    public Text biografiaActor;
    public Image actorImage;
    public Image countryImage;
    public Scrollbar scrollRect;
    #endregion
    [Header("Portrait")]
    #region PortraitText
    //public Text titulo_p;
    public Text nombreActor_p;
    public Text papelActor_p;
    public Text sexoActor_p;
    public Text biografiaActor_p;
    public Image actorImage_p;
    public Image countryImage_p;
    public Scrollbar scrollRect_p;
    #endregion


    [Header("Orientation")]
    public GameObject landscape;
    public GameObject portrait;

    DataBaseManager _manager;

    // Use this for initialization
    void Start()
    {
        _manager = GameObject.Find("DataBaseManager").GetComponent<DataBaseManager>();
        _manager.GetActor(0);

        ShowInfo();
    }


    public void ShowInfo()
    {


        //titulo.text = _manager.pelicula.titulo;
        //titulo_p.text = _manager.pelicula.titulo;
        nombreActor.text = _manager.registro.actor.nombre;
        nombreActor_p.text = _manager.registro.actor.nombre;
        papelActor.text = _manager.registro.papel;
        papelActor_p.text = _manager.registro.papel;
        sexoActor.text = _manager.registro.actor.sexo.ToString();
        sexoActor_p.text = _manager.registro.actor.sexo.ToString();
        biografiaActor.text = _manager.registro.actor.biografia;
        biografiaActor_p.text = _manager.registro.actor.biografia;

        Sprite[] sprites = Resources.LoadAll<Sprite>("Images/ActorSheet");
        actorImage.sprite = sprites[_manager.registro.actor.id_actor];
        actorImage_p.sprite = sprites[_manager.registro.actor.id_actor];
        sprites = Resources.LoadAll<Sprite>("Images/Flags");
        countryImage.sprite = sprites[(int)_manager.registro.actor.id_nacion];
        countryImage_p.sprite = sprites[(int)_manager.registro.actor.id_nacion];

        scrollRect.value = 1;
        scrollRect_p.value = 1;

    }

    private void Update()
    {
        bool orientation = (Screen.width > Screen.height);

        landscape.SetActive(orientation); //Activa landscape cuando ancho > alto
        portrait.SetActive(!orientation); //Activa portrait cuando ancho < alto
    }


    public void NextActor()
    {
        _manager.NextActor();
        ShowInfo();
    }
    public void PrevActor()
    {
        _manager.PrevActor();
        ShowInfo();
    }


}
