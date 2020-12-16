using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class EnemyController : MonoBehaviour
{
    public float health;
    public float speed;
    public float volume = 1.0f;
    public int damage = 1;
    private Transform target;
    public Animator animator;
    public ParticleSystem damagedPrefab;
    public AudioSource hurtSound;
    public Rigidbody2D rb;

    AudioSource audioSource;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
            
        if(health <= 0)
        {
            health = 0;
            GetComponent<Rigidbody2D>();    
            Instantiate(damagedPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject,0.2f);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Projectile")
        {
            Instantiate(damagedPrefab,transform.position,Quaternion.identity);
            health -= damage;
            animator.SetTrigger("Hit");
            audioSource.Play();
        }
    }
}