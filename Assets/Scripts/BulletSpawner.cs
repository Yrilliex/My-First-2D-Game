using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletGO;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Create a bullet instance
            GameObject tempBullet = Instantiate(bulletGO, transform.position, Quaternion.identity);
            AudioManager._instance.ShootSFX();
        }
    }
}
