using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager _instance;

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

    [Header ("AudioSource")]
    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;

    [Header("Audio Clips")]
    public AudioClip gameBGM;
    public AudioClip bulletSFX;
    public AudioClip enemySFX;
    public AudioClip enemybulletSFX;
    public AudioClip playerDeathSFX;
    //public AudioClip[] sfxClips;

    [Header("Audio Booleans")]
    public bool inMainMenu;
    public bool isBGMplaying;

    // Start is called before the first frame update
    void Start()
    {
        // Always need to start music with
        inMainMenu = false;
        isBGMplaying = false;

        // if Active Scene is Main Menu, set the "inMainMenu" to true and play the BGM audio clip
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            if (!inMainMenu)
            {
                inMainMenu = true;

                if (inMainMenu)
                {
                    BGM();
                }
            }
        }
    }

    public void BGM()
    {
        isBGMplaying = true;
        bgmAudioSource.loop = false;

        if(inMainMenu && isBGMplaying)
        {
            // Play BGM music now
            bgmAudioSource.clip = gameBGM;
            bgmAudioSource.Play();
            bgmAudioSource.loop = true;
        }
        else
        {
            // Don't play BGM music
            inMainMenu = false;
            isBGMplaying = false;
            bgmAudioSource.clip = null;
            bgmAudioSource.Stop();
            bgmAudioSource.loop = false;
        }
    }

   //public void MainMenuBGM()
   // {
   //     bgmAudioSource.Play();
   // }
   // public void StopBGM()
   // {
   //     bgmAudioSource.Stop();
   // }
    public void ShootSFX()
    {
        sfxAudioSource.PlayOneShot(bulletSFX);
    }
    public void PlayerDeathSFX()
    {
        sfxAudioSource.PlayOneShot(playerDeathSFX);
    }
    public void EnemyDeathSFX()
    {
        sfxAudioSource.PlayOneShot(enemySFX);
    }
    public void EnemyShootSFX()
    {
        sfxAudioSource.PlayOneShot(enemybulletSFX);
    }
}
