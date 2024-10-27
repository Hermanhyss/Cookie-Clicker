using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
public class CookieGameScript : MonoBehaviour
{
    [SerializeField] int cookieCount = 0;
    [SerializeField] int CookieAdd = 1;
    [SerializeField] int CookieAddcost = 1;

    public bool EscOpen = false;

    public TMP_Text ShopCookieCost;
    public TMP_Text CookieText;
    public TMP_Text CookiePerClick;


    [SerializeField] GameObject NoCookies;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject ShopButton;
  
    void Start()
    {
        CookieText.text = "Cookies:" + cookieCount;
        EscOpen = false;
    }

    public void OnCookieClick()
    {
        //cookieCount++;

        if (CookieAdd > 1)
        {
            cookieCount += CookieAdd;
        }
        else
        {
            cookieCount++;
        }
        CookieText.text = "Cookies:" + cookieCount;
    }
    public void Update()
    {
        CookieText.text = "Cookies:" + cookieCount;
        ShopCookieCost.text = CookieAddcost + "cookies";
        CookiePerClick.text = CookieAdd + "Cookies";

    }

    public int GetCookieCount()
    {
        return cookieCount;
    }

    public void AddCookies(int amount)
    {
        cookieCount += amount;
        CookieText.text = "Cookies: " + cookieCount;
    }
    public void OnShopClick()
    {
        Shop.SetActive(true);
        ShopButton.SetActive(false);
    }
    public void ShopButtonClose()
    {
        ShopButton.SetActive(true);
        Shop.SetActive(false);
    }
    public IEnumerator BuyButton()
    {
        if (cookieCount >= CookieAddcost)
        {

            cookieCount -= CookieAddcost;
            CookieAddcost++;
            CookieAdd++;

        }
        else
        {
            NoCookies.SetActive(true);
            yield return new WaitForSeconds(1);
            NoCookies.SetActive(false);
        }

    }
    public void BuyButton1()
    {
        StartCoroutine(BuyButton());
    }

  
}