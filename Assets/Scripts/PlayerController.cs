using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private float moveInput;

    public float JumpForce;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    private int extraJumps;
    public int extraJumpValue;

    public GameObject endScreen;
    public GameObject startDialogue; 

    Vector3 originalPos;


    Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpValue;

        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        animator = GetComponent<Animator>(); 
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);

        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            flip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Lava")
        {
            this.gameObject.transform.position = originalPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "StartDialogue")
        {
            StartCoroutine(showDialogue());

        }
    }

    IEnumerator showDialogue()
    {
        startDialogue.GetComponent<SpriteRenderer>().enabled = true; 
        yield return new WaitForSeconds(10);
        startDialogue.GetComponent<SpriteRenderer>().enabled = false; 
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Update()
    {
        if (isGrounded)
        {
            extraJumps = 1;
        }

        if(moveInput != 0)
        {
            animator.enabled = true; 
        }

        else
        {
            animator.enabled = false; 
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
        }

        if (CoinScore.instance.coins == 0)
        {
            endScreen.GetComponent<SpriteRenderer>().enabled = true;
        }


    }

} 

