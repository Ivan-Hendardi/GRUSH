using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Throw : MonoBehaviour
{
    public float fireTimer = 0.5f;
    public float ProjectileSpeed = 10.0f;

    public Transform firePoint;
    public GameObject projectilePrefab;
    public AudioSource audioSource;
    public Rigidbody2D rb;
    public Camera cam;

    Vector2 cursorScreen;

    void Start()
    {
        GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.localPosition = new Vector2(0,0);
        

        if(Input.GetButtonDown("Fire1"))
        {
            // GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);  
            // Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            // rb.AddForce(firePoint.up * ProjectileSpeed, ForceMode2D.Impulse);
            // PlayThrowSound();
            Fire();
        } 
    }

    void FixedUpdate()
    {
            cursorScreen = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x,Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x,transform.position.y);
            Vector2 direction = cursorScreen - myPos;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
    }

    void Fire()
    {
        fireTimer -= Time.time;

        if(fireTimer <= 0.0f)
        {
            GameObject bullet = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);  
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * ProjectileSpeed, ForceMode2D.Impulse);
            PlayThrowSound();
            fireTimer = 0.5f;
        }
    }
    void PlayThrowSound()
    {
        audioSource.Play();
    }
}