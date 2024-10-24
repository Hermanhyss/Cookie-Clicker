using UnityEngine;

public class ButtonScale : MonoBehaviour
{
  public void PointerEnter()
    {
        transform.localScale = new Vector2(1.5f, 1.5f);
    }

    public void PointerExit()
        { transform.localScale = new Vector2(1, 1); }
}
