using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c_GotoNextScene : MonoBehaviour {
    public bool touch = false;
    public bool mirrortouch = false;
    public static c_GotoNextScene scene;
    // Use this for initialization
    void Start () {
        scene = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (touch && mirrortouch)
        {
            SceneManager.LoadScene("portalroom"); 
        }
	}
    
}
