using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ResourceValue : MonoBehaviour
{
    public int coinValue;
    public ParticleSystem rockBreakingPreFab;
    public AudioSource rockSource;
    Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform")
        {
            
            Instantiate(rockBreakingPreFab,transform.position,Quaternion.identity);
            Coin.value += coinValue;
            Destroy(gameObject,1.5f);
            rockSource.Play();
        }
    }
}
