using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] allItems; // Drag all your ScriptableObjects here in the Inspector
    public Transform shopItemsParent; // Parent object for shop item UI
    public GameObject shopItemPrefab; // UI prefab for displaying items

    private ShopItem[] displayedItems;

    private void Start()
    {
        GenerateShopItems();
    }

    public void GenerateShopItems()
    {
        // Generate 3 random items
        displayedItems = new ShopItem[3];

        for (int i = 0; i < displayedItems.Length; i++)
        {
            displayedItems[i] = GetRandomItem();
            DisplayItem(displayedItems[i], i);
        }
    }

    private ShopItem GetRandomItem()
    {
        // Weighted random generation by rarity
        int randomIndex = Random.Range(0, allItems.Length);
        return allItems[randomIndex];
    }

    private void DisplayItem(ShopItem item, int index)
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
