using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool pauseMenuActive;

    EnemyController em;

    private static readonly bool activeInHierarchy;

    void Start()
    {
        //Panel starts close first
        pauseMenu.SetActive(false);
        pauseMenuActive = false;

        em = GetComponent<EnemyController>();
    }

    //   void Update()
    //    {
    //        // When Esc is pressed, call "PauseMenu"
    //        if (Input.GetKeyDown(KeyCode.Escape))
    //        {
    //            if (!pauseMenuActive)
    //            {
    //                PauseGamePanel();
    //            }
    //            else
    //            {
    //                ResumeGameByEsc();
    //            }
    //        }
    //    }
    //    public void PauseGamePanel()
    //    {
    //        pauseMenuActive = true;
    //        pauseMenu.SetActive(true); // Show panel

    //        em.EnemyStopAttack();
    //        em.EnemyContinueAttack();
    //    }
    //    public void ResumeGame()
    //    {
    //        pauseMenuActive = false;
    //        pauseMenu.SetActive(false); // close panel
    //    }
    //    public void ResumeGameByEsc()
    //    {
    //        pauseMenuActive = false;
    //        pauseMenu.SetActive(false); // close panel
    //    }
    //    public void BackToMainMenu()
    //    {
    //        SceneManager.LoadScene(0);
    //    }
}
