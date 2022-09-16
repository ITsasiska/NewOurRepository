using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform SpawnerPos;
    [SerializeField] GameObject Room;
    public void OnTriggerEnter2D(Collider2D other)
    { 
       Instantiate(Room, SpawnerPos.position, Quaternion.identity);
        
    }
    
}
