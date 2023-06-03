using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_head : MonoBehaviour {
    public GameObject spawnblock;
    public GameObject block;
    public GameObject player_head;
    public GameObject head1;
	// Use this for initialization
	void Start () {
        player_head.gameObject.SetActive(false);
        head1.gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x > -5)
        {
            spawnblock.gameObject.SetActive(true);
            block.gameObject.SetActive(true);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("head"))
        {
            player_head.gameObject.SetActive(true);
            head1.gameObject.SetActive(false);
        }
    }
}
