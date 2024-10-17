using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoulGameScript : MonoBehaviour
{
    [SerializeField] int soulCount = 0;
    [SerializeField] int SoulAdd = 1;
    [SerializeField] int SoulAddCost = 1;

    public bool EscOpen = false;

    public TMP_Text ShopSoulCost;
    public TMP_Text SoulText;
    public TMP_Text SoulPerClick;

    [SerializeField] GameObject NoSouls;
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject ShopButton;
    [SerializeField] GameObject EscMenu;

    void Start()
    {
        SoulText.text = "Souls: " + soulCount;
        EscOpen = false;
    }

    public void OnSoulClick()
    {
        if (SoulAdd > 1)
        {
            soulCount += SoulAdd;
        }
        else
        {
            soulCount++;
        }
        SoulText.text = "Souls: " + soulCount;
    }

    public void Update()
    {
        SoulText.text = "Souls: " + soulCount;
        ShopSoulCost.text = SoulAddCost + " souls";
        SoulPerClick.text = SoulAdd + " Souls";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("EscPressed");
            if (!EscOpen)
            {
                EscMenu.SetActive(true);
                EscOpen = true;
                Debug.Log("no");
            }
        }
    }

    public int GetSoulCount()
    {
        return soulCount;
    }

    public void AddSouls(int amount)
    {
        soulCount += amount;
        SoulText.text = "Souls: " + soulCount;
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
        if (soulCount >= SoulAddCost)
        {
            soulCount -= SoulAddCost;
            SoulAddCost++;
            SoulAdd++;
        }
        else
        {
            NoSouls.SetActive(true);
            yield return new WaitForSeconds(1);
            NoSouls.SetActive(false);
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
