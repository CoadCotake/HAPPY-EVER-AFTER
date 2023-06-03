using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_camerachange : MonoBehaviour {
    public GameObject main;
    public GameObject sub;
    private int a;
	// Use this for initialization
	void Start () {
        sub.gameObject.SetActive(true);
        main.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x > -5)
        {
            sub.gameObject.SetActive(false);
            main.gameObject.SetActive(true);
            
        }
	}
}
