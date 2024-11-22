using UnityEngine;

public class StatsHandlerGettersAndSetters : MonoBehaviour
{
    public static StatsHandlerGettersAndSetters Instance;

    [Header("Combat Stats")]
    private int damage {get;set;}
    private float weaponRange {get;set;}
    private float knockbackForce {get;set;}
    private float knockbackTime {get;set;}
    private float stunTime {get;set;}
    private int projectileDamage {get;set;}
    private int projectileVelocity {get;set;}

    [Header("Movement Stats")]
    private int speed {get;set;}

    [Header("Player Stats")]
    private int maxHealth {get;set;}
    private int currentHealth {get;set;}
    private int experience {get;set;}
    private int level {get;set;}
    private int totalCoins {get;set;}
    private int totalEnergy {get;set;}
    private int currentEnergy {get;set;}

    //[Header("Enemy Stats")]
    //private int enemyMaxHealth {get;set;}
    //private int enemyCurrentHealth { get; set;}
    //private int enemySpeed { get; set; }

    private void Awake(){
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
