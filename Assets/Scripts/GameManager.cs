using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager _instance;

    void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
    #endregion

    public int monsterKill;
    public bool winLevel;

    PauseMenu pm;
    WinGame wg;
    LoseGame lg;

    // Start is called before the first frame update
    void Start()
    {
        monsterKill = 0;
        winLevel = false;

        pm = GetComponent<PauseMenu>();
        wg = GetComponent<WinGame>();
        lg = GetComponent<LoseGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if (monsterKill == 3)
        {
            if(!winLevel)
            {
                winLevel = true;
            }
            GameGUIManager._instance.WinPanel();
        }
    }

    
    
    
    
}
