using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    void Awake()
    {
         rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction, float force)
    {
        rb.AddForce (direction * force);
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 50.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
