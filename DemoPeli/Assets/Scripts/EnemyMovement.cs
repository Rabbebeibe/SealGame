using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    Rigidbody2D enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
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
}
