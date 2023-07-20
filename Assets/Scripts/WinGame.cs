using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public GameObject winPanel;
    public bool winPanelActive;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        winPanelActive = false;
    }
}


//// Update is called once per frame
//public void WinPanel()
//{
//    if (!winPanelActive)
//    {
//        winPanelActive = true;
//        winPanel.SetActive(true);
//    }
//}
//public void NextLevel()
//{
//    //SceneManager.LoadScene(0);
//}
//public void BackToMainMenu()
//{
//    SceneManager.LoadScene(0);
//}

