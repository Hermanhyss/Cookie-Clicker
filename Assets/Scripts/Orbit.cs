using UnityEngine;

public class Orbit2D : MonoBehaviour
{
    public Transform planet;  // The object to orbit around
    public float orbitSpeed = 50f;  // Speed of the orbit in degrees per second
    public float orbitDistance = 3f;  // Distance from the planet

    private float currentAngle = 0f;  // Initial angle

    void Update()
    {
        // Update the current angle based on orbit speed and time
        currentAngle += orbitSpeed * Time.deltaTime;

        // Keep the angle within 0 to 360 degrees
        if (currentAngle >= 360f) currentAngle -= 360f;

        // Calculate the new position in a circular orbit
        float x = planet.position.x + Mathf.Cos(currentAngle * Mathf.Deg2Rad) * orbitDistance;
        float y = planet.position.y + Mathf.Sin(currentAngle * Mathf.Deg2Rad) * orbitDistance;

        // Set the new position of the satellite
        transform.position = new Vector3(x, y, transform.position.z);
    }
}

