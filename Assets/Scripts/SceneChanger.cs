using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene("CookieClicker");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}

