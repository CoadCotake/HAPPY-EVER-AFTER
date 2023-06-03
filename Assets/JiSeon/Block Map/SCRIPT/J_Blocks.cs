using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Blocks : MonoBehaviour
{
    private Animator animatorController;

    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundCheck"))
        {
            animatorController.SetTrigger("Fall");
        }
    }
}
