using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGUIManager : MonoBehaviour
{
    #region Singleton
    public static GameGUIManager _instance;

    void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
    #endregion

    [Header ("Panel")]
    public GameObject pauseMenu;
    public GameObject winPanel;
    public GameObject losePanel;

    [Space(10)]
    [Header ("Boolean State")]
    public bool pauseMenuActive;
    public bool winPanelActive;
    public bool losePanelActive;

    PlayerController pc;
    EnemyController em;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        pauseMenuActive = false;
        winPanel.SetActive(false);
        winPanelActive = false;
        losePanel.SetActive(false);
        losePanelActive = false;

        em = GetComponent<EnemyController>();
        pc = GetComponent<PlayerController>();
    }

    void Update()
    {
        // When Esc is pressed, call "PauseMenu"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuActive)
            {
                PauseGamePanel();
            }
            
            else if (pauseMenuActive && pauseMenu.activeInHierarchy)
            {
                ResumeGameByEsc();
            }
        }
    }
    public void PauseGamePanel()
    {
        pauseMenuActive = true;
        pauseMenu.SetActive(true); // Show panel
    }
    public void ResumeGame()
    {
        pauseMenuActive = false;
        pauseMenu.SetActive(false); // close panel 
    }
    public void ResumeGameByEsc()
    {
        pauseMenuActive = false;
        pauseMenu.SetActive(false); // close panel
    }

    // Update is called once per frame
    public void WinPanel()
    {
        if (!winPanelActive)
        {
            winPanelActive = true;
            winPanel.SetActive(true);
        }
    }
    public void LosePanel()
    {
        if (!losePanelActive)
        {
            losePanelActive = true;
            losePanel.SetActive(true);
        }
    }
    public void NextLevel(int level)
    {
        if (level >=2 && level <= 6)
        {
            SceneManager.LoadScene(level);
        }
    }
    public void Retry(int level)
    {
        if (level >= 2 && level <= 6)
        {
            SceneManager.LoadScene(level);
        }
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelSelection()
    {
        SceneManager.LoadScene(1);
    }
}
