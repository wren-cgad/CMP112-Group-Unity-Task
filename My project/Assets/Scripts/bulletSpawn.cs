using UnityEngine;

public class bulletSpawn : MonoBehaviour
{
    public GameObject bullet;      // assign the PREFAB in the Inspector
    public GameObject player;
    public Transform firePoint;
    private float bulletSpeed = 25f;
    private float fireRate = 2f;   // bullets per second
    private float nextFireTime = 0f;

    void Update()
    {
        Vector2 dirToParent = transform.parent.TransformDirection(-(Vector2)transform.localPosition).normalized;
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.AddForce(dirToParent * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}