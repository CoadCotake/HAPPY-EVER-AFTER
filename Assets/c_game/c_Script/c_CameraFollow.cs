using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_CameraFollow : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object


    [SerializeField]
    private float ymin;

    [SerializeField]
    private float ymax;
    private Transform target;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("c_Player").transform;

    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(target.position.y, ymin, ymax), transform.position.z);
    }
}
