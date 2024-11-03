using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MinionManager : MonoBehaviour
{
    [SerializeField] int minionCount = 0;
    [SerializeField] int minionCost = 50;
    [SerializeField] float minionInterval = 1f;
    [SerializeField] int minionClickPower = 1;

    [SerializeField] GameObject satellitePrefab;
    [SerializeField] Transform planetTransform;

    private List<float> minionTimers = new List<float>();
    private CookieGameScript gameScript;
    private List<GameObject> satellites = new List<GameObject>();

    public TMP_Text MinionCountText;
    public TMP_Text MinionCostText;
    public GameObject NoCookies;
    public Planet planet;

    void Start()
    {
        gameScript = Object.FindAnyObjectByType<CookieGameScript>();
        UpdateMinionUI();
    }

    void Update()
    {
        // Update each minion's timer and trigger clicks if interval is reached
        for (int i = 0; i < minionTimers.Count; i++)
        {
            minionTimers[i] += Time.deltaTime;

            // If this minion's timer reaches its interval, trigger a click and reset its timer
            if (minionTimers[i] >= minionInterval)
            {
                MinionClick(i);
                minionTimers[i] = 0f;
            }
        }

        UpdateSatellitePositions();
    }

    public void BuyMinion()
    {
        if (gameScript.GetCookieCount() >= minionCost)
        {
            gameScript.AddCookies(-minionCost);
            minionCount++;
            minionCost += 10;
            UpdateMinionUI();

            // Create a new satellite and add it to the list
            GameObject newSatellite = Instantiate(satellitePrefab, planetTransform.position, Quaternion.identity);
            satellites.Add(newSatellite);

            // Initialize this minion's timer to a random offset to desynchronize clicks
            minionTimers.Add(Random.Range(0, minionInterval));
        }
        else
        {
            StartCoroutine(ShowNoCookiesMessage());
        }
    }

    private void MinionClick(int minionIndex)
    {
        // Trigger a pulse animation on the planet (visual feedback for the click)
        planet.TriggerPulse();

        // Calculate a random position within a radius around the planet for this minion's click
        Vector3 clickPosition = planetTransform.position + (Random.insideUnitCircle * 1.5f).ToVector3();

        // Use this click to add cookies
        gameScript.AddCookies(minionClickPower);

        // Optional: You could have each satellite move closer to this position temporarily, if desired
    }

    private void UpdateMinionUI()
    {
        MinionCountText.text = "Minions: " + minionCount;
        MinionCostText.text = "Minion Cost: " + minionCost + " cookies";
    }

    private IEnumerator ShowNoCookiesMessage()
    {
        NoCookies.SetActive(true);
        yield return new WaitForSeconds(1);
        NoCookies.SetActive(false);
    }

    private void UpdateSatellitePositions()
    {
        float angleStep = 360f / satellites.Count;

        for (int i = 0; i < satellites.Count; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;

            // Calculate satellite position based on angle around the planet
            float x = planetTransform.position.x + Mathf.Cos(angle) * 3f;
            float y = planetTransform.position.y + Mathf.Sin(angle) * 3f;

            satellites[i].transform.position = new Vector3(x, y, satellites[i].transform.position.z);
        }
    }
}

// Extension method for converting Vector2 to Vector3
public static class VectorExtensions
{
    public static Vector3 ToVector3(this Vector2 v2, float z = 0f)
    {
        return new Vector3(v2.x, v2.y, z);
    }
}






