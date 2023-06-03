using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class J_Player : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveInput;
    private Rigidbody2D rb;
    public Animator run;

    private bool facingright = true;
    public bool isGrounded;

    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;

    private int extrajumps;
    public int extrajumpsvalue;

    public Text starText;
    private bool CarryingStar = false;

    public GameObject DoorStar;

   


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        extrajumps = extrajumpsvalue;
        rb = GetComponent<Rigidbody2D>(); //컴포넌트를 불러옴
        UpdateStarText();

        DoorStar.gameObject.SetActive(false);
        

    }

    // Update is called once per frame
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("star"))
        {
            CarryingStar = true;
            UpdateStarText();
            Destroy(collision.gameObject);

        }
        else
        {
            DoorStar.gameObject.SetActive(false);
        }

        if (collision.CompareTag("TwoDoor"))
        {
            if (CarryingStar)
            {
                DoorStar.gameObject.SetActive(true);
                Invoke("GoToTheNextScene", 1f);
            }


        }
    }
    
    public void UpdateStarText()
    {
        starText.gameObject.SetActive(false);
        if (CarryingStar)
        {
            starText.gameObject.SetActive(true);
        }
    }

    public void GoToTheNextScene()
    {
        SceneManager.LoadScene("DarkMaze");
    }
}


