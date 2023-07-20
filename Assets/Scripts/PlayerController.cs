using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject playerGO;
    Animator anim;
    public float moveSpeed;
    public bool gotHit;
    public bool disableKey;
    public bool disableKeyOnWin;
    PlayerAnimationManager pam;

    // Start is called before the first frame update
    void Start()
    {
        //Initialise Objects & Scripts here
        playerGO = GetComponent<GameObject>();
        anim = GetComponent<Animator>();
        pam = GetComponent<PlayerAnimationManager>();

        //Initialise variable here
        moveSpeed = 0.15f;
        gotHit = false;

        if(disableKey != false || disableKey != true)
        {
            disableKey = false;
            Time.timeScale = 1f;
        }
        if (disableKeyOnWin != false || disableKeyOnWin != true)
        {
            disableKeyOnWin = false;
            Time.timeScale = 1f;
        }
    }

    public void OnTriggerEnter2D(Collider2D playerCol)
    {
        // When Enemy's bullet hits Player, Player die!!!
        if(playerCol.gameObject.CompareTag("BulletEnemy01"))
        {
            gotHit = true;
            AudioManager._instance.PlayerDeathSFX();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameGUIManager._instance.pauseMenuActive)
        //{
        //    gameObject.GetComponent<PlayerController>().enabled = false;
        //    //Time.timeScale = 0f;
        //}
        //else
        //{
        //    Time.timeScale = 1f;
        //}
        // When no keys are being pressed, go back to playing "Idle" Animation
        if (!Input.GetKey(KeyCode.A)
            && !Input.GetKey(KeyCode.LeftArrow)
            && !Input.GetKey(KeyCode.D)
            && !Input.GetKey(KeyCode.RightArrow))
        {
            pam.PlayIdleAnim();

            // If disableKey is true, and Player got hit by Enemy's Bullet, open the lose Panel on screnn.
            if (disableKey)
            {
                GameGUIManager._instance.LosePanel();

                if (GameGUIManager._instance.losePanel.activeInHierarchy)
                {
                    gameObject.GetComponent<PlayerController>().enabled = false;
                    Time.timeScale = 0f;
                }
            }
            // If disableKeyOnWin is true, and Player won open the Win Panel on screnn.
            if (disableKeyOnWin)
            {
                GameGUIManager._instance.WinPanel();

                if (GameGUIManager._instance.winPanel.activeInHierarchy)
                {
                    gameObject.GetComponent<PlayerController>().enabled = false;
                    Time.timeScale = 0f;
                }
            }
        }

        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position -= new Vector3(moveSpeed, 0.0f, 0.0f);
            gameObject.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);

            pam.PlayMoveAnim();
        }
        // Move Right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(moveSpeed, 0.0f, 0.0f);
            gameObject.transform.localScale = new Vector3(-5.0f, 5.0f, 5.0f);
            pam.PlayMoveAnim();
        }

        // When player gets hit by Enemy's Bullet, set 'gotHit' to true
        if (gotHit)
        {
            if (!disableKey)
            {
                disableKey = true;
            }
            //GameGUIManager._instance.LosePanel();
        }

        // When player completes objective, disable keys on Win
        if (GameManager._instance.winLevel)
        {
            disableKeyOnWin = true;
        }
    }
}
