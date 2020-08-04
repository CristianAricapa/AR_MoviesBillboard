using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void LoadNewScene(int scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
    public void ExitApplication()
    {
        Application.Quit();
    }
}
