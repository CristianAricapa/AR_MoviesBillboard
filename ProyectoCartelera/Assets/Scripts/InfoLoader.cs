using UnityEngine;

public class InfoLoader : MonoBehaviour
{

    private DataBaseManager _manager;

    // Use this for initialization
    void Awake()
    {
        _manager = GameObject.Find("DataBaseManager").GetComponent<DataBaseManager>();
        
    }

    private void OnEnable()
    {
        _manager.LoadData(gameObject.name);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Principal");
    }
}
