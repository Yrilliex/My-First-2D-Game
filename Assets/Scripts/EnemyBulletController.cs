using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public bool isEnemyBulletEnabled = true;
    float enemyBulletSpeed = 0.1f;
    float enemyOutOfBoundScreen = -6.0f;
        
    // Update is called once per frame
    void Update()
    {
        if (isEnemyBulletEnabled)
        {
            //Make sure the spawned enemy Bullet gameobject is active
            gameObject.SetActive(true);
            // Move the bullet upwards
            transform.position -= new Vector3(0f, enemyBulletSpeed * Time.timeScale, 0f);
        }

        // Destroy this enemy bullet gameobject when it goes offscreen
        if (transform.position.y < enemyOutOfBoundScreen)
        {
            isEnemyBulletEnabled = false; // Force gameobject to turn off if it exist in scene still
            Destroy(gameObject);
            AudioManager._instance.EnemyShootSFX();
        }
    }

    private void OnTriggerEnter2D(Collider2D enemyBulletcol)
    {
        if (enemyBulletcol.gameObject.CompareTag("Player"))
        {
            isEnemyBulletEnabled = false;
            EnemyBulletHalt();
        }
    }

    void EnemyBulletHalt()
    {
        if (!isEnemyBulletEnabled && gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
