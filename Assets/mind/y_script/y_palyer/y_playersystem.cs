using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class y_playersystem : MonoBehaviour {
    public GameObject player;
    public static int up = 0;
    private void Start()
    {

        if(y_playersystem1.down==1)
        {
            player.transform.position = new Vector2(12.56f, 27.17328f);
        }
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("up"))
        {
            up = 1;
            y_playersystem1.down = 0;
            SceneManager.LoadScene("y_piace1");

        }
    }

  

}
