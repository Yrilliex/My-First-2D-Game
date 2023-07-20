using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject exitPanel;
    public bool exitPanelActive;

    void Start()
    {
        exitPanel.SetActive(false);
        exitPanelActive = false;
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGameButton()
    {
        if (!exitPanelActive)
        {
            exitPanelActive = true;
            exitPanel.SetActive(true); // Show panel
        }
    }
    public void ExitYesButton()
    {
        Application.Quit(); // Quit the application or game
    }
    public void ExitNoButton()
    {
        if (exitPanelActive)
        {
            exitPanelActive = false;
            exitPanel.SetActive(false); // close panel
        }
    }
}
