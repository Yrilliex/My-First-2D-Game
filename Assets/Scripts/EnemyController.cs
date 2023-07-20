using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyBullet;
    public bool isFacingLeft;
    //public bool isAttacking;
    public static bool isMoving;
    public float enemyMoveSpeed;
    [SerializeField] float bulletSpawnDelayTimer;
    [SerializeField] float bulletSpawnDelayDuration;


    // Start is called before the first frame update
    void Start()
    {
        //Game Variable Setup
        isFacingLeft = true;
        //isAttacking = true;
        isMoving = true;
        enemyMoveSpeed = 0.01f;
        bulletSpawnDelayTimer = 0.0f;
        bulletSpawnDelayDuration = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameGUIManager._instance.pauseMenuActive)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if (isFacingLeft)
        {
            transform.position -= new Vector3(enemyMoveSpeed * Time.timeScale, 0f, 0f);
            transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        }
        else
        {
            transform.position += new Vector3(enemyMoveSpeed * Time.timeScale, 0f, 0f);
            transform.localScale = new Vector3(-5.0f, 5.0f, 5.0f);
        }

        // Spawn Bullet Timer in real-time
        bulletSpawnDelayTimer += Time.deltaTime;

        // Randomly spawn bullets from Enemy's Position
        Random.Range(-6.0f, 6.0f);

        if (bulletSpawnDelayTimer > bulletSpawnDelayDuration)
        {
            SpawnEnemyBullet();
        }
    }

    public void SpawnEnemyBullet()
    {
        // Spawn Enemy's Bullets
        GameObject tempEnemyBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
        bulletSpawnDelayTimer = 0f; //Reset "bulletSpawnDelayTimer" back to 0
    }

    public void ChangeDirection()
    {
        // Toggle from True to False and viceversa
        isFacingLeft = !isFacingLeft;
    }

    //public void EnemyStopAttack()
    //{
    //    gameObject.GetComponent<EnemyController>().enabled = false;
    //    gameObject.GetComponent<Animator>().enabled = false;
    //}

    //public void EnemyContinueAttack()
    //{
    //    gameObject.GetComponent<EnemyController>().enabled = true;
    //    gameObject.GetComponent<Animator>().enabled = true;
    //}

    private void OnTriggerEnter2D(Collider2D enemyCol)
    {
        if(enemyCol.gameObject.CompareTag("Bullet01"))
        {
            Debug.Log(GameManager._instance.monsterKill + " + 3");
            GameManager._instance.monsterKill += 1;
            Destroy(gameObject);
            AudioManager._instance.EnemyDeathSFX();
        }
    }
}
