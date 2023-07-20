using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public GameObject LevelPanel;
    public bool LevelPanelActive;

    void Start()
    {
        LevelPanel.SetActive(false);
        LevelPanelActive = false;
    }
    public void LevelSelectionButton()
    {
        if (!LevelPanelActive)
        {
            LevelPanelActive = true;
            LevelPanel.SetActive(true); // Show panel
        }
    }
    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level01");
    }

    public void SelectLevel2()
    {
        SceneManager.LoadScene("Level02");
    }

    public void SelectLevel3()
    {
        SceneManager.LoadScene("Level03");
    }

    public void SelectLevel4()
    {
        SceneManager.LoadScene("Level04");
    }

    public void SelectLevel5()
    {
        SceneManager.LoadScene("Level05");
    }
}
