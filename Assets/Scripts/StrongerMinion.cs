using UnityEngine;
using System.Collections;

public class StrongerMinion : MonoBehaviour
{
    public int clickPower = 5;  
    private float clickInterval = 1.5f; 
    private float timer = 0f;

    private CookieGameScript gameScript;
    private Planet planet;

    public void Initialize(CookieGameScript gameScript, Planet planet)
    {
        this.gameScript = gameScript;
        this.planet = planet;

      
        transform.position = new Vector3(
            Random.Range(-8f, 8f),  
            Random.Range(-4f, 4f),
            0f
        );
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= clickInterval)
        {
            Click();
            timer = 0f;
        }
    }

    private void Click()
    {
       
        planet.TriggerPulse();

      
        gameScript.AddCookies(clickPower);
    }
}

