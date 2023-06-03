using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shooting_GameManager.levelcheck);
    }

    public void retry()
    {
        switch (shooting_GameManager.levelcheck)
        {
            case 1:

                SceneManager.LoadScene("easy");
                Time.timeScale = 1;
                break;
            case 2:
                SceneManager.LoadScene("normal");
                Time.timeScale = 1;
                break;
            case 3:
                SceneManager.LoadScene("hard");
                Time.timeScale = 1;
                break;
        }
       
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene("Game Start");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
