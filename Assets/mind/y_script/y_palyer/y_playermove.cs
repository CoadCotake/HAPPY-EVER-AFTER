using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_playermove : MonoBehaviour {
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

    private SpriteRenderer spriteRenderer;

    //cord box
    bool[] cordbox;
    string cordcheck="";
    public Animator doorA;
    public GameObject door;
    public SpriteRenderer c1;
    public SpriteRenderer c2;
    public SpriteRenderer c3;
    public SpriteRenderer c4;
    public SpriteRenderer c5;
    public GameObject flyingshoes;
    public Animator NeedA;
    private float up;
    
    void Start()
    {
        Time.timeScale = 1;
        extrajumps = extrajumpsvalue;
        rb = GetComponent<Rigidbody2D>(); //컴포넌트를 불러옴
        spriteRenderer = GameObject.Find("y_player").GetComponent<SpriteRenderer>();
        cordbox = new bool[5];
        cordbox[0] = true;
        cordbox[1] = true;
        cordbox[2] = true;
        cordbox[3] = true;
        cordbox[4] = true;
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
        if(Needshoes == false)
        {
            flyingshoes.SetActive(true);
        }

        run.SetFloat("speed", Mathf.Abs(moveInput));

        if (isGrounded == true)
        {
            extrajumps = extrajumpsvalue;
        }
        if (Needshoes == true)
        {
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
        else if(Needshoes==false)
        {
            up = Input.GetAxis("Vertical");
            speed = 7;
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x , up * speed);
            
        }
        
       
        if (cordcheck.Length == 5)
        {
            if (cordcheck == "41235")
            {
                doorA.SetBool("bool", true);
                Invoke("doordestroy",1.33f);
            }
            else
            {
                cordcheck = "";
                c1.color = new Color(255, 255, 255, 255f);
                cordbox[0] = true;
                c2.color = new Color(255, 255, 255, 255f);
                cordbox[1] = true;
                c3.color = new Color(255, 255, 255, 255f);
                cordbox[2] = true;
                c4.color = new Color(255, 255, 255, 255f);
                cordbox[3] = true;
                c5.color = new Color(255, 255, 255, 255f);
                cordbox[4] = true;
            }
        }
    }
    void doordestroy()
    {
        Destroy(door);
    }

    bool Needshoes = true;
    bool isUnBeatTime=false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="enemy" &&! isUnBeatTime)
        {
            isUnBeatTime = true;
            Vector2 attackedVelocity = Vector2.zero;
            if (other.gameObject.transform.position.x > transform.position.x)
            {
                attackedVelocity = new Vector2(0f, 3f);
            }
            else
            {
                attackedVelocity = new Vector2(0f, 3f);
            }
            rb.AddForce(attackedVelocity,ForceMode2D.Impulse);
            StartCoroutine("UnBeatTime");
            
        }  
        
        if(other.CompareTag("shoes"))
        {
            Needshoes = false;
            Destroy(other.gameObject);
            
        }
        if(other.CompareTag("Need"))
        {
            if (Needshoes == true)
            {
                NeedA.SetBool("bool", true);
            }
        }

        //------------------------cord
        if (cordbox[0] == true)     //1
        {
            if (other.CompareTag("cord1"))    
            {
                c1.color = new Color(255, 255, 255, 0.5f);
                cordcheck += "1";
                cordbox[0] = false;
            }
        }
        if (cordbox[1] == true)     //1
        {
            if (other.CompareTag("cord2"))   
            {
                c2.color = new Color(255, 255, 255, 0.5f);
                cordbox[1] = false;
                cordcheck += "2";
            }
        }

        if (cordbox[2] == true)     //3
        {
            if (other.CompareTag("cord3"))  
            {
                c3.color = new Color(255, 255, 255, 0.5f);
                cordbox[2] = false;
                cordcheck += "3";
            }
        }

        if (cordbox[3] == true)     //4
        {
            if (other.CompareTag("cord4"))  
            {
                c4.color = new Color(255, 255, 255, 0.5f);
                cordbox[3] = false;
                cordcheck += "4";
            }
        }

        if (cordbox[4] == true)     //5
        {
            if (other.CompareTag("cord5"))   
            {
                c5.color = new Color(255, 255, 255, 0.5f);
                cordbox[4] = false;
                cordcheck += "5";
            }
        }
   
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if(other.CompareTag("Need"))
        {
            if (Needshoes == true)
                NeedA.SetBool("bool", false);
        }
    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;
        while (countTime < 10)
        {
            if (countTime % 2 == 0)
                spriteRenderer.color = new Color(255, 255, 255, 0.8f);
            else
                spriteRenderer.color = new Color(255, 255, 255, 0.5f);

            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);

        isUnBeatTime = false;

        yield return null;
    }
}
