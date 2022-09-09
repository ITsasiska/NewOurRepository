using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float destroyTime = 3;
    public float speed = 10;
    public int damage;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    private void Update()
    {
        gameObject.transform.Translate(0, 1 * speed * Time.deltaTime, 0);
    }
}
