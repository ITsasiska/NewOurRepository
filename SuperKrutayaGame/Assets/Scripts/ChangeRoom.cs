using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    public Vector3 cameraChangepos;
    public Vector3 playerChangeposition;
    public Camera cam;
    void Start()
    {
        cam = Camera.main.GetComponent<Camera>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.CompareTag("Player"))
        {
            other.transform.position += playerChangeposition;
            cam.transform.position += cameraChangepos;
        }
    }
}
