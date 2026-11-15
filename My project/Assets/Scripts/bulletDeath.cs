using Unity.VisualScripting;
using UnityEngine;

public class bulletDeath : MonoBehaviour
{

    // Update is called once per frame
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
