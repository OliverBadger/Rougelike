using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsHandler : MonoBehaviour
{
    public static StatsHandler Instance;

    [Header("Combat Stats")]
    //public int damage;
    //public float weaponRange;
    //public float knockbackForce;
    //public float knockbackTime;
    //public float stunTime;
    public int projectileDamage;
    public int projectileVelocity;

    [Header("Movement Stats")]
    public int speed;

    [Header("Player Stats")]
    public int maxHealth;
    public int currentHealth;
    public Slider slider;
    //public int experience;
    //public int level;
    public int totalCoins;
    public TextMeshProUGUI coinDisplay;
    //public int totalEnergy;
    //public int currentEnergy;

    //[Header("Enemy Stats")]
    //public int enemyMaxHealth;
    //public int enemyCurrentHealth;
    //public int enemySpeed;

    private void Awake(){
        if (Instance == null) { 
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        currentHealth = maxHealth;

        // Set UI Fields
        coinDisplay.text = totalCoins.ToString();
        slider.value = currentHealth;
    }

    public void AddCoin()
    {
        totalCoins++;
        coinDisplay.text = totalCoins.ToString(); 
    }

    public void PlayerTakesDamage(int damage)
    {
        if (currentHealth > 0)
        {
            slider.value = currentHealth;
            currentHealth -= damage;
        }
    }
}
