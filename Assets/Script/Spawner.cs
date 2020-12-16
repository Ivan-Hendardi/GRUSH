using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public ParticleSystem spawnParticle;
    public float spawnDelay = 3.0f;
    public float spawnTime = 5.0f;

    void Start()
    {
        InvokeRepeating("Spawn",spawnDelay,spawnTime);
    }
    
    void Spawn()
    {
        Instantiate(spawnParticle,transform.position,Quaternion.identity);
        Instantiate(enemy,transform.position,Quaternion.identity);
    }
}
