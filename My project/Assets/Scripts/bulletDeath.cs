using Unity.VisualScripting;
using UnityEngine;

public class bulletDeath : MonoBehaviour
{

    // Update is called once per frame
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Debug.Log("The bullet has touched the enemy.");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}