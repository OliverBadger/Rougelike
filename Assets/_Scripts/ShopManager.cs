using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] allItems; // Drag all your ScriptableObjects here in the Inspector
    public GameObject SpawnPoint1, SpawnPoint2, SpawnPoint3;


    private ShopItem[] displayedItems;

    private void Start()
    {
        GenerateShop();
    }

    private void GenerateShop()
    {
        foreach (ShopItem shopsItem in allItems) 
        {

        }
        disedItems = displayedItems;
        for (int i = 0; i <= 3; i++)
        {
            DisplayItem(,i);
        }
    }

    private void DisplayItem(int index)
    {
        // Instantiate the shop item UI
        GameObject itemUI = Instantiate(shopItemPrefab, shopItemsParent);
        itemUI.GetComponent<ShopItemUI>().Setup(item, this, index);
    }

    public void PurchaseItem(int index)
    {
        ShopItem item = displayedItems[index];

        if (StatsHandler.Instance.totalCoins >= item.cost)
        {
            StatsHandler.Instance.totalCoins -= item.cost;

            // Apply the item's bonuses
            StatsHandler.Instance.projectileDamage += item.bonusDamage;
            StatsHandler.Instance.maxHealth += item.bonusHealth;
            StatsHandler.Instance.currentHealth += item.bonusHealth;
            StatsHandler.Instance.speed += item.bonusSpeed;

            Debug.Log($"Purchased {item.itemName}");
        }
        else
        {
            Debug.Log("Not enough coins!");
        }
    }
}
