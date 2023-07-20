using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D platformCol)
    {
        if (platformCol.gameObject.CompareTag("Enemy"))
        {
            // Make the game object who touched this collider to change direction
            platformCol.gameObject.GetComponent<EnemyController>().ChangeDirection();
        }
    }
}
