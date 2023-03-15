using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public float damage;
    Rigidbody2D enemyRb;

    public UIManager uiManager;
    [SerializeField] private Behaviour[] components;
    public Health playerHealth;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        speed = 5;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            enemyRb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            enemyRb.velocity = new Vector2(-speed, 0f);
        }

        if (uiManager.gameOverScreen.activeSelf == true)
        {
            stopMovement();

            if (IsFacingRight())
            {
                enemyRb.velocity = new Vector2(speed, 0f);
            }
            else
            {
                enemyRb.velocity = new Vector2(-speed, 0f);
            }

        }
        
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            transform.localScale = new Vector2(-(Mathf.Sign(enemyRb.velocity.x)), transform.localScale.y);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void stopMovement()
    {
        if (uiManager.gameOverScreen.activeSelf == true)
        {
            foreach (Behaviour component in components)
            {
                component.enabled = false;
            }
            speed = 0;
        }
        
    }
}
