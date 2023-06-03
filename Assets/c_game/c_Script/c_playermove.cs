using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class c_playermove : MonoBehaviour {
    public float speed;
    public float jumpforce;
    private float moveInput;
    public Animator run;
    private Rigidbody2D rb;

    private bool facingright = true;
    public bool isGrounded;

    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;

    private int extrajumps;
    public int extrajumpsvalue;

    public static c_playermove pmove;
    public bool movedoor = false;
    void Start()

    {
        Time.timeScale = 1;
        pmove = this;
        extrajumps = extrajumpsvalue;
        rb = GetComponent<Rigidbody2D>(); //컴포넌트를 불러옴

    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatisground);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingright == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingright == true && moveInput < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);

    }


    void Update()

    {
        run.SetFloat("speed", Mathf.Abs(moveInput));

        if (isGrounded == true)
        {
            extrajumps = extrajumpsvalue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extrajumps > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            extrajumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extrajumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("door"))
        {
            c_GotoNextScene.scene.touch = true;
        }
        if (collision.CompareTag("touchfalse"))
        {
            c_GotoNextScene.scene.touch = false;
        }
        if (collision.CompareTag("mirrordoor"))
        {
            c_GotoNextScene.scene.mirrortouch = true;
        }
        if (collision.CompareTag("mirrortouchfalse"))
        {
            c_GotoNextScene.scene.mirrortouch = false;
        }

    }
}
