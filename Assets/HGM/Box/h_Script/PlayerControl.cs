using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.

	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
	public float jumpForce = 1000f;         // Amount of force added when the player jumps.

    public int isActive = 0;
    public int coolDown = 0;
    public int confusion = 0;
    public int chaos = 0;
    public int exhaustion = 0;
    public int doorCount = 0;
    private int isRunning = 0;
    public bool hasKey = false;
    public static bool pause = false;

    [SerializeField] public Image Normal;
    [SerializeField] public Image ReverseAll;
    [SerializeField] public Image ReverseNonJump;
    [SerializeField] public Image ReverseExhaustion;
    [SerializeField] public Image ADdownJump;
    [SerializeField] public Image ADNonJump;
    [SerializeField] public Image ADExhaustion;

    public Image IKey;
    public SpriteRenderer Con1;
    public SpriteRenderer Con2;
    public SpriteRenderer Con3;

    private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private Animator anim;                  // Reference to the player's animator component.

    public GameObject door1;
    public GameObject door2;
    public GameObject key1;
    public GameObject key2;
    public GameObject rollbackPoint;

    public Text_Dialogue Text_Dialogue1;
    public Text_Dialogue Text_Dialogue2;

    void Awake()
	{
		groundCheck = transform.Find("groundCheck1");
    }

    void Start()
    {
        Time.timeScale = 1;
        Text_Dialogue1.ShowDialogue();
    }

    void Update()
	{
        if (!pause)
        {
            grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
            switch (confusion)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) { jump = true; }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.DownArrow) && grounded) { jump = true; }
                    if (isRunning == 0)
                    {
                        isRunning = 1;
                        Invoke("purification", 8);
                    }
                    break;
                case 2:
                    jump = false;
                    if (isRunning == 0)
                    {
                        isRunning = 1;
                        Invoke("purification", 8);
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
                    {
                        if (exhaustion <= 0)
                        {
                            exhaustion++;
                        }
                        else if (exhaustion <= 1)
                        {
                            jump = true;
                            exhaustion = 0;
                        }
                    }
                    if (isRunning == 0)
                    {
                        isRunning = 1;
                        Invoke("purification", 8);
                    }
                    break;
            }
            if (isActive == 1 && coolDown == 1)
            {
                chaos = Random.Range(1, 3);
                confusion = Random.Range(1, 4);
                isActive = 0;
                KeyState(true);
                Normal.gameObject.SetActive(false);
                Invoke("cooldown", 16);
            }

            float h = 0;
            switch (chaos)
            {
                case 0:
                    h = Input.GetAxis("Horizontal");
                    break;
                case 1:
                    h = -Input.GetAxis("Horizontal");
                    if (isRunning == 0)
                    {
                        isRunning = 1;
                        Invoke("purification", 8);
                    }
                    break;
                case 2:
                    if (Input.GetKey("a") || Input.GetKey("d"))
                    {
                        h = Input.GetAxis("Horizontal");
                    }
                    if (isRunning == 0)
                    {
                        isRunning = 1;
                        Invoke("purification", 8);
                    }
                    break;
            }

            if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

            if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
                GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (h > 0 && !facingRight)
                Flip();
            else if (h < 0 && facingRight)
                Flip();

            if (jump)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
                jump = false;
            }
        }
    }
	
	void Flip ()
	{
		facingRight = !facingRight;
        
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Trap"))
        {
            if(isActive == 0 && coolDown == 0)
            {
                isActive = 1;
                coolDown = 1;
            }
        }
        else if (collision.CompareTag("Key"))
        {
            if(doorCount == 0)
            {
                hasKey = true;
                key1.gameObject.SetActive(false);
                IKey.gameObject.SetActive(true);
            }
            else if(doorCount == 1)
            {
                hasKey = true;
                key2.gameObject.SetActive(false);
                IKey.gameObject.SetActive(true);
            }
        }
        else if (collision.CompareTag("door"))
        {
            if (hasKey && doorCount == 0)
            {
                door1.gameObject.SetActive(false);
                doorCount++;
                hasKey = false;
                IKey.gameObject.SetActive(false);
            }
            else if(hasKey && doorCount == 1)
            {
                door2.gameObject.SetActive(false);
                hasKey = false;
                IKey.gameObject.SetActive(false);
            }
        }
        else if (collision.CompareTag("Exit?"))
        {
            transform.position = new Vector3(rollbackPoint.transform.position.x, rollbackPoint.transform.position.y, rollbackPoint.transform.position.z);
            purification();
            Normal.gameObject.SetActive(false);
            Text_Dialogue2.ShowDialogue();
            pause = true;
        }
        if (collision.CompareTag("Exit1"))
        {
            SceneManager.LoadScene("Confusion");
        }
        else if (collision.CompareTag("Exit2"))
        {
            SceneManager.LoadScene("mirror room");
        }
    }

    void cooldown()
    {
        coolDown = 0;
        isRunning = 0;
    }

    void purification()
    {
        KeyState(false);
        Normal.gameObject.SetActive(true);
        confusion = 0;
        chaos = 0;
    }

    void KeyState(bool _flag)
    {
        switch (chaos)
        {
            case 1:
                if(confusion == 1)
                {
                    ReverseAll.gameObject.SetActive(_flag);
                    Con1.gameObject.SetActive(_flag);
                }
                else if(confusion == 2)
                {
                    ReverseNonJump.gameObject.SetActive(_flag);
                    Con2.gameObject.SetActive(_flag);
                }
                else
                {
                    ReverseExhaustion.gameObject.SetActive(_flag);
                    Con3.gameObject.SetActive(_flag);
                }
                break;
            case 2:
                if(confusion == 1)
                {
                    ADdownJump.gameObject.SetActive(_flag);
                    Con1.gameObject.SetActive(_flag);
                }
                else if(confusion == 2)
                {
                    ADNonJump.gameObject.SetActive(_flag);
                    Con2.gameObject.SetActive(_flag);
                }
                else
                {
                    ADExhaustion.gameObject.SetActive(_flag);
                    Con3.gameObject.SetActive(_flag);
                }
                break;
        }
    }
}
