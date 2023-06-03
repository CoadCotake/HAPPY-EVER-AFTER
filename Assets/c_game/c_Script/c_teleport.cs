using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_teleport : MonoBehaviour {
    // Use this for initialization
    public int teleportx;
    public int teleporty;

    public static c_teleport telpo;
    [SerializeField]
    public static int count=0;
	void Start () {
        telpo = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            count++;
            hit.transform.position = new Vector3(teleportx, teleporty, 0);
        }
            
    }
    
}
