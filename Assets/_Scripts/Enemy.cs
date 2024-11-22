using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    private int health;
    public int maxHealth;
    public float chaseSpeed = 3.0f; 
    public float attackRange = 1.5f;
    public float detectionRange = 5.0f; // Range within which the enemy detects the player
    public float attackCooldown = 2.0f; // Time between attacks

    [Header("Projectile Settings")]
    public GameObject projectile; // The projectile prefab to spawn
    public float shootInterval = 2.0f; // Time between shots
    public float projectileSpeed = 5.0f; // Speed of the projectile
    public int projectileDamage = 10; // Damage dealt by the projectile
    private float shootTimer; // Timer to control shooting intervals


    private Animator animator;
    public Slider slider;
    private bool isAttacking = false; // Flag to manage attack state
    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        health = maxHealth;
        slider.value = health;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");
        // Initialise the timer
        shootTimer = shootInterval;
    }

    private void Update()
    {
        if (player == null) return; // Stop if no player is found
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            // Stop chasing and attack
            if (!isAttacking)
            {
                Attack();
            }
        }
        else if (distanceToPlayer <= detectionRange)
        {
            // Chase the player
            ChasePlayer();
        }
        else
        {
            // Idle state
            StopChasing();
        }
    }

    private void ShootAtPlayer()
    {
        // Spawn the projectile
        GameObject projectilePrefab = Instantiate(projectile, transform.position, Quaternion.identity);

        // Calculate direction toward the player
        Vector2 direction = (player.transform.position - transform.position).normalized;

        // Set projectile velocity
        Rigidbody2D rb = projectilePrefab.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }

        // Assign damage to the projectile
        TestProjectile projectileScript = projectilePrefab.GetComponent<TestProjectile>();
        if (projectileScript != null)
        {
            projectileScript.damage = projectileDamage;
        }
    }


    private void ChasePlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;

        // Update animation (e.g., walking animation)
        if (animator != null)
        {
            animator.SetBool("isMoving", true);
        }
    }

    private void StopChasing()
    {
        rb.velocity = Vector2.zero;

        // Update animation (e.g., idle animation)
        if (animator != null)
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Attack()
    {
        isAttacking = true;

        // Play attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Optionally deal damage to the player
        DealDamageToPlayer();

        isAttacking = false;
    }

    private void DealDamageToPlayer()
    {
        // Implement player damage logic here
        Debug.Log("Player is hit!");
    }

    public void DealDamage(int damage){
        // Animation for hurt and dead
        //Debug.Log("Enemy has been hit");

        if(health > 0){
            animator.SetTrigger("Hit");
            
            health -= damage;
            slider.value = health;
        }
        CheckDeath();
    }

    private void CheckOverheal()
    {
        if(health > maxHealth){
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);

            Destroy(gameObject, 1.5f);
        }
    }
}
