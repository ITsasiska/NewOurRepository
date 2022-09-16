using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float speed = 20;
    
    
    public float health;
    public float maxHealth;
    public int armor;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }       

    void Update()
    {        
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetAxis("Horizontal") != 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void TakeDamage(int bulletDamage)
    {
        if (armor < bulletDamage)
        {
            health = health - (bulletDamage - armor);
        }
        else
        {
            health -= 1;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
