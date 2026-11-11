using JetBrains.Annotations;
using UnityEngine;

public class bulletSpawn : MonoBehaviour
{
    public GameObject bullet;
    
    public GameObject player;
    public Transform firePoint;
    public int bulletSpeed = 25;

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bullet = Instantiate( bullet, firePoint.position, player.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
