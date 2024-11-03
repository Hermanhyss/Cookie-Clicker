using UnityEngine;
using System.Collections.Generic;

public class StrongerMinion : MonoBehaviour
{
    public int clickPower = 5;
    private float clickInterval = 1.5f;
    private float timer = 0f;

    private CookieGameScript gameScript;
    private Planet planet;
    private List<BoxCollider2D> spawnZones;

    public void Initialize(CookieGameScript gameScript, Planet planet, List<BoxCollider2D> spawnZones)
    {
        this.gameScript = gameScript;
        this.planet = planet;
        this.spawnZones = spawnZones;

        
        if (spawnZones != null && spawnZones.Count > 0)
        {
            BoxCollider2D selectedZone = spawnZones[Random.Range(0, spawnZones.Count)];

            
            float x = Random.Range(selectedZone.bounds.min.x, selectedZone.bounds.max.x);
            float y = Random.Range(selectedZone.bounds.min.y, selectedZone.bounds.max.y);
            transform.position = new Vector3(x, y, 0f);  
        }
        else
        {
            Debug.LogWarning("No spawn zones assigned to StrongerMinion.");
        }
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



