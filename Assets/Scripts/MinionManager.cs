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

    [SerializeField] int strongMinionCost = 200;
    [SerializeField] GameObject satellitePrefab;
    [SerializeField] GameObject strongerMinionPrefab;
    [SerializeField] Transform planetTransform;

    [SerializeField] List<BoxCollider2D> strongMinionSpawnZones; // List of spawn zones for stronger minions

    private int strongMinionCount = 0; // Track the number of strong minions
    private float minionTimer = 0f;
    private CookieGameScript gameScript;
    private List<GameObject> satellites = new List<GameObject>();
    private List<StrongerMinion> strongerMinions = new List<StrongerMinion>();

    public TMP_Text MinionCountText;
    public TMP_Text MinionCostText;
    public TMP_Text StrongMinionCostText;
    public TMP_Text StrongMinionCountText;  // New text field to show the count
    public GameObject NoCookies;
    public Planet planet;

    void Start()
    {
        gameScript = Object.FindAnyObjectByType<CookieGameScript>();
        UpdateMinionUI();
    }

    void Update()
    {
        minionTimer += Time.deltaTime;
        if (minionTimer >= minionInterval && minionCount > 0)
        {
            AutoClick();
            minionTimer = 0f;
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

            GameObject newSatellite = Instantiate(satellitePrefab, planetTransform.position, Quaternion.identity);
            satellites.Add(newSatellite);
        }
        else
        {
            StartCoroutine(ShowNoCookiesMessage());
        }
    }

    public void BuyStrongerMinion()
    {
        if (gameScript.GetCookieCount() >= strongMinionCost)
        {
            gameScript.AddCookies(-strongMinionCost);

            GameObject newStrongerMinionObj = Instantiate(strongerMinionPrefab);
            StrongerMinion newStrongerMinion = newStrongerMinionObj.GetComponent<StrongerMinion>();
            newStrongerMinion.Initialize(gameScript, planet, strongMinionSpawnZones);

            strongerMinions.Add(newStrongerMinion);

            // Increment the strong minion count and update the UI
            strongMinionCount++;
            strongMinionCost += 50;
            UpdateMinionUI();
        }
        else
        {
            StartCoroutine(ShowNoCookiesMessage());
        }
    }

    private void AutoClick()
    {
        planet.TriggerPulse();
        gameScript.AddCookies(minionClickPower * minionCount);
    }

    private void UpdateMinionUI()
    {
        MinionCountText.text = "DemonBaby: " + minionCount;
        MinionCostText.text = "DemonBaby Cost: " + minionCost + " cookies";
        StrongMinionCostText.text = "SoulGhost Cost: " + strongMinionCost + " cookies";
        StrongMinionCountText.text = "SoulGhosts: " + strongMinionCount; // Display the strong minion count
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

            float x = planetTransform.position.x + Mathf.Cos(angle) * 3f;
            float y = planetTransform.position.y + Mathf.Sin(angle) * 3f;

            satellites[i].transform.position = new Vector3(x, y, satellites[i].transform.position.z);
        }
    }
}
















