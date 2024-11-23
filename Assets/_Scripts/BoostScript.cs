using UnityEngine;
using static UnityEditor.Progress;

public class BoostScript : MonoBehaviour
{
    public ShopItem item;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyEffectsToPlayer();
            Destroy(gameObject);
        }
    }

    private void ApplyEffectsToPlayer()
    {
        StatsHandler.Instance.projectileDamage += item.bonusDamage;
        StatsHandler.Instance.currentHealth += item.bonusHealth;
        StatsHandler.Instance.maxHealth += item.bonusHealth;
        StatsHandler.Instance.speed += item.bonusSpeed;
        
        Debug.Log($"Player picked up {item.itemName}!");
    }

}
