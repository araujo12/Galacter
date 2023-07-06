using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Event : MonoBehaviour
{
    public GameObject spawnEnemy, spawnBoss,textOBJ,btnexit, pauseTxt;
    public AudioSource bgSoundGame, bgSoundBoss;
    

    private bool bossEventON,isPause;
    private float timeEvent, endGameEvent;  

    void Start()
    {
        bossEventON = false; timeEvent = 0;    
        textOBJ.SetActive(false);
        btnexit.SetActive(false);
        pauseTxt.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {
        BossEvent();
        EndGame();
        PauseGame();
        MusicThemeOff();

    }

    void BossEvent()
    {
        timeEvent += Time.deltaTime;

        if(timeEvent >= 150)
        {            
            spawnBoss.SetActive(true);
            bossEventON = true;
        }

        if (bossEventON == true)
        {
            timeEvent = 0;
            bgSoundGame.volume -= Time.deltaTime;
            bgSoundBoss.volume += Time.deltaTime;
        }
    }

    public void EndGame()
    {
        if (BossController.bossDead == true)
        {
            endGameEvent += Time.deltaTime;
            if(endGameEvent >= 5)
            {
                spawnEnemy.SetActive(false);
                textOBJ.SetActive(true);
                btnexit.SetActive(true);
            }
        }
    }

    void PauseGame()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;

            if( isPause )
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        pauseTxt.SetActive(true);
    }

    void UnPause()
    {
        Time.timeScale = 1;
        pauseTxt.SetActive(false);
    }

    public void MusicThemeOff()
    {
        GameObject musicMenu = GameObject.FindGameObjectWithTag("MusicController");
        musicMenu.SetActive(false);
    }
}
