﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class J_GotoNextScene : MonoBehaviour {

    public GameObject doorcheck;

    // Use this for initialization
    void Start () {
      
	}

    // Update is called once per frame
    void Update()
    {
     
 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("door"))
        {
            SceneManager.LoadScene("QuizMap");
        }
    }
}
