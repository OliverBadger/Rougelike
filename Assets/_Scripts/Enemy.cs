using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private int health;
    public int maxHealth;
    private Animator animator;
    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = health;
        animator = GetComponent<Animator>();
    }

    public void DealDamage(int damage){
        // Animation for hurt and dead
        //Debug.Log("Enemy has been hit");

        if(health > 0){
            animator.SetTrigger("Hit");
            
            health -= damage;
            slider.value = health;
            CheckDeath();
        }        
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

            Destroy(gameObject);
        }
    }
}
