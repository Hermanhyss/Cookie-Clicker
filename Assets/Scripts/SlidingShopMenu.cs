using UnityEngine;

public class SlidingShopMenu : MonoBehaviour
{
    
    public RectTransform shopPanel;  
    public float slideSpeed = 5f;    

    private Vector2 hiddenPosition;  
    private Vector2 shownPosition;   
    private bool isVisible = false;  

    private void Start()
    {
       
        hiddenPosition = new Vector2(-shopPanel.rect.width, shopPanel.anchoredPosition.y);
        shownPosition = new Vector2(0, shopPanel.anchoredPosition.y);

        
        shopPanel.anchoredPosition = hiddenPosition;
    }

    public void ToggleShop()
    {
        isVisible = !isVisible;

        StopAllCoroutines(); 
        StartCoroutine(SlideShop(isVisible ? shownPosition : hiddenPosition));
    }

    private System.Collections.IEnumerator SlideShop(Vector2 targetPosition)
    {
        while (Vector2.Distance(shopPanel.anchoredPosition, targetPosition) > 0.1f)
        {
            shopPanel.anchoredPosition = Vector2.Lerp(
                shopPanel.anchoredPosition, targetPosition, Time.deltaTime * slideSpeed);
            yield return null;  
        }

        
        shopPanel.anchoredPosition = targetPosition;
    }
}

