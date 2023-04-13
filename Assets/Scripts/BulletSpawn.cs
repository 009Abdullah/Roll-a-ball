using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20.0f;
    public float bulletLifetime = 2.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = transform.forward * bulletSpeed;
            }
            
            Destroy(bullet, bulletLifetime);
            Debug.Log("running destroy?");
        }
    }

    

}
