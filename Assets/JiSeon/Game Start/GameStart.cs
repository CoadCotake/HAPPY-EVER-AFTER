using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject button;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoNextScene()
    {
        SceneManager.LoadScene("QuizMap");
    }

}
