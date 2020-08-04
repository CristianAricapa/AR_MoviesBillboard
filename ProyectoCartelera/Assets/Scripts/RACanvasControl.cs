using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class RACanvasControl : MonoBehaviour
{
    #region TextVar
    public Text tituloPelicula;
    public Text añoPelicula;
    public Text directorPelicula;
    public Text sinopsisPelicula;
    #endregion

    public GameObject UI;
    public GameObject VideoP;
    public Button PlayButton;
    public Sprite playImage;
    public Sprite pauseImage;
    public Image countryImage;

  
    public bool ActivedTrailer = false;


    public VideoPlayer VideoPlayer;
    DataBaseManager _manager;
    public General.EnumMovies movie;

    // Use this for initialization
    void Start()
    {
        _manager = GameObject.Find("DataBaseManager").GetComponent<DataBaseManager>();
        //VideoPlayer = transform.FindChild("Video").GetComponent<VideoPlayer>();
        VideoPlayer = gameObject.transform.GetChild(1).GetChild(2).GetComponent<VideoPlayer>();
        //VideoPlayer = GetComponentInChildren<VideoPlayer>();

        PlayButton = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Button>();

        UI.SetActive(true);
        VideoP.SetActive(false);

        ShowMovieInfo();
    }


    public void ShowMovieInfo()
    {
        #region TextAssign
        tituloPelicula.text = _manager.pelicula.titulo;
        añoPelicula.text = _manager.pelicula.year.ToString();
        directorPelicula.text = _manager.pelicula.director;
        sinopsisPelicula.text = _manager.pelicula.sinopsis;

        Sprite[] sprites = Resources.LoadAll<Sprite>("Images/Flags");
        countryImage.sprite = sprites[(int)_manager.pelicula.id_nacion];

        #endregion

    }


    public void DisplayTrailer()
    {
        ActivedTrailer = true;
        UI.SetActive(false);
        VideoP.SetActive(true);
        VideoPlayer.Play();
        Camera.main.GetComponent<StopVideos>().SetCurrentVideo(movie);
    }


    public void Pause_ResumeTrailer()
    {
        if (VideoPlayer.isPlaying)
        {
            PlayButton.GetComponent<Image>().sprite = playImage;
            VideoPlayer.Pause();
        }
        else
        {
            PlayButton.GetComponent<Image>().sprite = pauseImage;
            VideoPlayer.Play();
        }
    }
    public void StopTrailer()
    {
        ActivedTrailer = false;
        VideoPlayer.Stop();
        UI.SetActive(true);
        VideoP.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (VideoPlayer.isPlaying) VideoPlayer.Pause();
            else VideoPlayer.Play();
        }
    }




}
