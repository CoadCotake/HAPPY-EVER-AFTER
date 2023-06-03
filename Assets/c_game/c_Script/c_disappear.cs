using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_disappear : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("delete", 7f);
	}
	void delete()
    {
        Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
