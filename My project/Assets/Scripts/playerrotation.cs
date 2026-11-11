using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    float currentAngle = 0f;
    float targetAngle = 0f;
    const float SPEED = 100f; // rotation speed in degrees per second
    const float LERP_FACTOR = 2f; // higher = faster smoothing

    void FixedUpdate()
    {
        // adjust target angle based on input
        if (Input.GetKey(KeyCode.RightArrow))
        {
            targetAngle -= SPEED * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            targetAngle += SPEED * Time.fixedDeltaTime;
        }

        // smoothly interpolate currentAngle toward targetAngle
        currentAngle = Mathf.Lerp(currentAngle, targetAngle, LERP_FACTOR * Time.fixedDeltaTime);

        // apply rotation
        transform.eulerAngles = new Vector3(0, 0, currentAngle);
    }
}
