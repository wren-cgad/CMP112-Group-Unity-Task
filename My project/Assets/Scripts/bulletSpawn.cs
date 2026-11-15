using UnityEngine;

public class bulletSpawn : MonoBehaviour
{
    public GameObject bullet;      // assign the PREFAB in the Inspector
    public GameObject player;
    public Transform firePoint;
    public float bulletSpeed = 25f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}