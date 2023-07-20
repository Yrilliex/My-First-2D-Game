using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    public GameObject losePanel;
    public bool losePanelActive;
    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        losePanel.SetActive(false);
        losePanelActive = false;
        pc = GetComponent<PlayerController>();
    }
    //public void LosePanel()
    //{
    //    if (!losePanelActive)
    //    {
    //        losePanelActive = true;
    //        losePanel.SetActive(true);
    //    }
    //}
    //public void Retry()
    //{
    //    SceneManager.LoadScene(1);
    //}
    //public void BackToMainMenu()
    //{
    //    SceneManager.LoadScene(0);
    //}
}
