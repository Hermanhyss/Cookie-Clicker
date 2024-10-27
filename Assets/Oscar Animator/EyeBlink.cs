using UnityEngine;

public class EyeBlink : MonoBehaviour
{
    private Animator animator;
    private float blinkInterval = 8.0f;    
    private float blinkDuration = 0.1f;    
    private float timer;                 

    void Start()
    {
        animator = GetComponent<Animator>();
        timer = blinkInterval;             
    }

    void Update()
    {
        timer -= Time.deltaTime;            

       
        if (timer <= 0)
        {
            StartCoroutine(Blink());       
            timer = blinkInterval;          
        }
    }

    private System.Collections.IEnumerator Blink()
    {
        animator.SetBool("IsOpen", false);  
        yield return new WaitForSeconds(blinkDuration); 
        animator.SetBool("IsOpen", true);   
    }
}




