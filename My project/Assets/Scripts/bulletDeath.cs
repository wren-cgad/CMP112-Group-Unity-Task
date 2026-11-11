using Unity.VisualScripting;
using UnityEngine;

public class bulletDeath : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 20 || transform.position.y < -20 || transform.position.x > 50 || transform.position.x < -50)
        {
            Destroy(gameObject);
        }
        }

    
}
