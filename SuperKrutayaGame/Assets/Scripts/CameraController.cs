using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    Vector3 target;
    public float trackingSpeed = 1.5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (player)
        {
            Vector3 currenPosition = Vector3.Lerp(transform.position, target, trackingSpeed * Time.deltaTime);
            transform.position = currenPosition;

            target = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
