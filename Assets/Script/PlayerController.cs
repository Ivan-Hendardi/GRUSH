using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    public int MaxHealth = 10;
    public static float currentHealth;
    public float invincibleTimer;

    public HealthBar healthBar;
    public Animator animator;
    public ParticleSystem damagedPrefab;
    public GameObject gameOverUI;
    public GameObject UIDisabler;
    public GameObject inventoryUI;
    public AudioClip gameOver;
    public AudioSource hurt;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody2D;
    AudioSource audioSource;

    // ini akan berjalan ketika scene game berjalan
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = MaxHealth; 
    }

    // ini akan berjalan seiring game berjalan
    void FixedUpdate() 
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        float mixMovement = movementHorizontal + movementVertical;
        transform.Translate(new Vector2(movementHorizontal,movementVertical) * speed * Time.deltaTime);

        animator.SetFloat("Speed",Mathf.Abs(mixMovement));
        
        if(Input.GetMouseButton(0))
        {
            animator.SetTrigger("Attack");
        }

        if(Input.GetKey(KeyCode.E))
        {
            inventoryUI.SetActive(true);
        }

        if(currentHealth > MaxHealth)   
            {
                currentHealth = MaxHealth;
            }
        if(currentHealth <= 0)
            {
                //ketika player punya Health sudah 0 atau kurang dari 0, akan dipanggil function Death();
                //dan juga memainkan suara game over serta mendisplay kan panel game over
                animator.SetTrigger("Dead");
                gameOverUI.SetActive(true);
                UIDisabler.SetActive(false);
                AudioSource.PlayClipAtPoint(gameOver,transform.position);
                Death();

            }

        if(movementHorizontal > 0)
        {
            spriteRenderer.flipX = false;
            
        }
        else if(movementHorizontal < 0 )
        {
            spriteRenderer.flipX = true;
        }
    }

    //memasuki trigger dan cek apakah musuh bertag "Enemy", jika iya jalankan Hurt();
    void OnTriggerStay2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Enemy")
        {
            Hurt();
        }
    }
    //sambungan dari yang di atas, metode ini mulai dengan menjalankan timer untuk cek apakah player
    //sedang kena damage
    //jika iya, akan berjalan proses damage terhadap player dan timer invincible akan ulang
    void Hurt()
    {
        
        invincibleTimer -= Time.deltaTime;

        if(invincibleTimer <= 0.0f)
        {
            animator.SetTrigger("Hit");
            PlayerController.currentHealth -= 1;
            Instantiate(damagedPrefab,transform.position,Quaternion.identity);
            hurt.Play();
            invincibleTimer = 1.0f;
        }
    }

    //method/function ini 
    void Death()
    {
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}