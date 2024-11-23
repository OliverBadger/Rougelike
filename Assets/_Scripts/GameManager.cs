using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ShopItem[] allItems; // Drag all ScriptableObjects here
    public Transform[] spawnPoints; // Set spawn points in the scene
    private ShopItem[] selectedItems;

    private void Start()
    {
        GenerateItems();
    }

    public void GenerateItems()
    {
        selectedItems = new ShopItem[3]; // To store selected items

        for (int i = 0; i < selectedItems.Length; i++)
        {
            selectedItems[i] = GetRandomItem();
            SpawnItem(selectedItems[i], spawnPoints[i]);
        }
    }

    private ShopItem GetRandomItem()
    {
        // Weighted random selection based on rarity (example logic)
        int randomIndex = Random.Range(0, allItems.Length);
        return allItems[randomIndex];
    }

    private void SpawnItem(ShopItem item, Transform spawnPoint)
    {
        if (item.prefab != null)
        {
            Instantiate(item.prefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"Item {item.itemName} has no assigned prefab.");
        }
    }

}
