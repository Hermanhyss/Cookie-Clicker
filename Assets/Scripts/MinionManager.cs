using UnityEngine;
using TMPro;
using System.Collections;

public class MinionManager : MonoBehaviour
{
    [SerializeField] int minionCount = 0;
    [SerializeField] int minionCost = 50;
    [SerializeField] float minionInterval = 1f;
    [SerializeField] int minionClickPower = 1;

    private float minionTimer = 0f;
    private CookieGameScript gameScript;
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
        minionTimer += Time.deltaTime;
        if (minionTimer >= minionInterval && minionCount > 0)
        {
            AutoClick();
            minionTimer = 0f;
        }
    }

    public void BuyMinion()
    {
        if (gameScript.GetCookieCount() >= minionCost)
        {
            gameScript.AddCookies(-minionCost);
            minionCount++;
            minionCost += 10;
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
        MinionCountText.text = "Minions: " + minionCount;
        MinionCostText.text = "Minion Cost: " + minionCost + " cookies";
    }

    private IEnumerator ShowNoCookiesMessage()
    {
        NoCookies.SetActive(true);
        yield return new WaitForSeconds(1);
        NoCookies.SetActive(false);
    }
}


