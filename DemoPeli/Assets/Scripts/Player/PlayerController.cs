using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float hInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private bool isGrounded;
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 direction;
    [SerializeField] private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        animator.SetFloat("horizontal", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * hInput * Time.deltaTime);

        if(hInput > 0 && facingRight)
        {
            Flip();
        }

        else if (hInput < 0 && !facingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
