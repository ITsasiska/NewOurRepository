using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    public float speed = 20;
    private Vector3 mousePosition;
    private Vector2 currentDirection = new Vector3(0f, 1f, 0f);
    public float rotateSpeed = 5f;
    public float health;
    public float maxHealth;
    public int armor;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Walk()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        currentDirection = Vector2.Lerp(currentDirection, difference, Time.deltaTime * rotateSpeed);
        transform.up = currentDirection;
    }   

    void Update()
    {
        Walk();

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
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
}
