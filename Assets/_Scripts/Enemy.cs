using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int health;
    public int maxHealth;
    public float chaseSpeed = 3.0f; 
    public float attackRange = 1.5f;
    public float detectionRange = 5.0f; // Range within which the enemy detects the player
    public float attackCooldown = 2.0f; // Time between attacks
    private float tempAC; // Time between attacks
    
    
    private Animator animator;
    public Slider slider;
    private bool isAttacking = false; // Flag to manage attack state
    private Rigidbody2D rb;
    private GameObject player;
    private Shooting shoot;

    void Start()
    {
        health = maxHealth;
        slider.value = health;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            Debug.Log("Player Not Found");
        else
            Debug.Log("This is the object found" + player + player.name);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        shoot = GetComponent<Shooting>();

        tempAC = attackCooldown;

    }

    private void FixedUpdate()
    {

        Debug.Log("Slider is: " + slider);
        Debug.Log("Animator is: " + animator);
        Debug.Log("RigidBody is: " + rb);
        Debug.Log("Player is: " + player);

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        attackCooldown -= Time.deltaTime;
        if (attackCooldown < 0)
        {
            // Reset timer
            attackCooldown = tempAC;

            Attack();
        }

        if (distanceToPlayer <= attackRange)
        {
            // Stop chasing and attack
            if (!isAttacking)
            {
                //Attack();
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

    private void ChasePlayer()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * chaseSpeed;

        // Update animation (e.g., walking animation)
        if (animator != null)
        {
            animator.SetBool("isMoving", true);
        }
    }

    private void StopChasing()
    {
        rb.linearVelocity = Vector2.zero;

        // Update animation (e.g., idle animation)
        if (animator != null)
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void Attack()
    {
        shoot.Shoot(player.transform.position, gameObject.transform.position);
        isAttacking = true;

        // Play attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }

        // Optionally deal damage to the player
        //DealDamageToPlayer();

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
