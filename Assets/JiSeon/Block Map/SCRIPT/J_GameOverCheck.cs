using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class J_GameOverCheck : MonoBehaviour
{
    public GameObject GameOverCheck;
    public GameObject GameOverCheck_r;
    public GameObject GameOverCheck_l;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gameoverCheck"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
