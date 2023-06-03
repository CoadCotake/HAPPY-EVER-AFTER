using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class y_playersystem1 : MonoBehaviour {
    public static int down = 0;
    public GameObject player;
    private void Start()
    {
        if (y_playersystem.up == 1)
        player.transform.position = new Vector2(-8.6f, 4.24f);
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("sky"))
        {

            SceneManager.LoadScene("easy");

        }
        if (hit.CompareTag("down"))
        {
            down = 1;
            y_playersystem.up = 0;
            SceneManager.LoadScene("y_piace");
            
        }
    }
}
