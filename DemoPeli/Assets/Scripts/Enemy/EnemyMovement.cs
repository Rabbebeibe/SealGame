using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float damage;
    
    Rigidbody2D enemyRb;

    [SerializeField] private UIManager uiManager;
    [SerializeField] private Behaviour[] components;
    [SerializeField] private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        speed = 6;     
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

        //Stop enemy movement when game over screen or win screen is active
        if (uiManager.gameOverScreen.activeSelf == true || uiManager.youWinScreen.activeSelf == true)
        {
            stopMovement();
        }
        
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Flip enemy sprite
        if(other.tag == "Ground")
        {
            transform.localScale = new Vector2(-(Mathf.Sign(enemyRb.velocity.x)), transform.localScale.y);
        }
        
    }

    //Check collision between player and enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void stopMovement()
    {
        //Disable selected components    
        foreach (Behaviour component in components)
            {
                component.enabled = false;
            }
            speed = 0;
    
    }
}
