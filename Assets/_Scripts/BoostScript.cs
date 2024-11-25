using UnityEngine;

public class BoostScript : MonoBehaviour
{
    public ShopItem item;
    public ShopManager SM;

    public void Start()
    {
        SM = FindFirstObjectByType<ShopManager>(); 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"The Item Being Passed is {item.itemName}");
        if (other.CompareTag("Player")) 
            if(StatsHandler.Instance.totalCoins >= item.cost)
            {
                SM.PurchaseItem(item);
                ApplyEffectsToPlayer();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Not Enough Coins");
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
