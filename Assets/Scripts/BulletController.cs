using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public bool isBulletEnabled = true;
    float bulletSpeed = 10.0f;
    float outOfBoundScreen = 6.0f;

    // Update is called once per frame
    void Update()
    {
        if(isBulletEnabled)
        {
            //Make sure the spawned Bullet gameobject is active
            gameObject.SetActive(true);
            // Move the bullet upwards
            transform.position += new Vector3(0f, bulletSpeed * Time.deltaTime, 0f);
        }

        // Destroy this bullet gameobject when it goes offscreen
        if(transform.position.y > outOfBoundScreen)
        {
            isBulletEnabled = false; // Force gameobject to turn off if it exist in scene still
            Destroy(gameObject);
        }

    }
}
