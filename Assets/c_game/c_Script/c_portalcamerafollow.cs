using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_portalcamerafollow : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object

    [SerializeField]
    private float xmin;
    [SerializeField]
    private float ymin;
    [SerializeField]
    private float xmax;
    [SerializeField]
    private float ymax;
    private Transform target;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    public int a;
    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("Player").transform;

    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xmin, xmax), Mathf.Clamp(target.position.y+a, ymin, ymax), transform.position.z);
    }
}
