using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector2 currentDirection = new Vector3(0f, 1f, 0f);
    public float rotateSpeed = 5f;

    protected void Rotata()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference = mousePosition - transform.position;
        difference.Normalize();
        currentDirection = Vector2.Lerp(currentDirection, difference, Time.deltaTime * rotateSpeed);
        transform.up = currentDirection;
    }

    private void Update()
    {
        Rotata();
    }
}
