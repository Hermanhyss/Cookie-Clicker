using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    public Vector3 largeScale = new Vector3(1.2f, 1.2f, 1f);
    public float pulseDuration = 0.1f; 

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void TriggerPulse()
    {
        StartCoroutine(PulseCoroutine());
    }

    private IEnumerator PulseCoroutine()
    {

        float elapsedTime = 0f;
        while (elapsedTime < pulseDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, largeScale, elapsedTime / pulseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = largeScale;


        elapsedTime = 0f;
        while (elapsedTime < pulseDuration)
        {
            transform.localScale = Vector3.Lerp(largeScale, originalScale, elapsedTime / pulseDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = originalScale;
    }
}






