using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
    [SerializeField] GameObject EscMenu;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("EscPressed");
            if (EscOpen == false)
            {
                EscMenu.SetActive(true);
                EscOpen = true;
                Debug.Log("no");
            }
            //while (EscOpen == true)
            //{
            //    if (Input.GetKeyDown(KeyCode.Escape))
            //    { }
            //    EscMenu.SetActive(false);
            //    EscOpen = false;
            //    Debug.Log("yes");
            //}
            
        }
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
        if(cookieCount >= CookieAddcost)
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

    public void MainMenu()
    {
        SceneManager.LoadScene("StartingScene");
    }
}
