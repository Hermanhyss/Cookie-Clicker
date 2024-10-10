using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    
    
    
    [SerializeField] GameObject GameList;
    [SerializeField] GameObject CloseList;
    [SerializeField] GameObject GameListButton;


    void Start()
    {
        
    }

    public void OnListClick()
    {
        GameListButton.SetActive(false);
        GameList.SetActive(true);
    }

    public void OnCloseListClick()
    { 
        GameListButton.SetActive(true); 
        GameList.SetActive(false);
    }

    public void OnCookieStart()
    {
        SceneManager.LoadScene("CookieClicker");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
