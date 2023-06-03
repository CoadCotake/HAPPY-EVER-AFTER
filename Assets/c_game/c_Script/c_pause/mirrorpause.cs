using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mirrorpause : MonoBehaviour {
    bool IsPause;
    public GameObject pauseMenuUI;

    // Use this for initialization
    void Start()
    {
        IsPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (IsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;
    }
    public void Mainmenu()
    {
        //SceneManager.LoadScene("") 메인화면으로보내자
    }
    public void Restart()
    {
        SceneManager.LoadScene("mirror room");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
