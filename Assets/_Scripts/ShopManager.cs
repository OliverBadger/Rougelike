using System;
using UnityEngine;
using static UnityEditor.Progress;
using Random = System.Random;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] allItems; // Drag all your ScriptableObjects here in the Inspector
    public GameObject[] SpawnPoints;


    private ShopItem[] displayedItems;

    private void Start()
    {
        GenerateShop();
    }

    private void GenerateShop()
    {
        System.Random random = new Random();
        int randomNumber = random.Next(1, 6); // Generates a number between 1 (inclusive) and 6 (exclusive)
        Console.WriteLine("Random number between 1 and 5: " + randomNumber);

        // Gets Spawn point position and puts it on item
        foreach (ShopItem shopsItem in allItems) 
        {
            //Random Selection for shop items
        }
        
        for (int i = 0; i < 3; i++)
        {
            //Displaying eachof the items in the spawnpoints here
            DisplayItem(i);
        }
    }

    private void DisplayItem(int index)
    {
        // Instantiate the shop item UI
        Debug.Log($"The Spawn point is {SpawnPoints[index].transform}");
        Debug.Log($"The Item is {allItems[index].name}");
        GameObject itemInstance = Instantiate(allItems[index].prefab, SpawnPoints[index].transform.position, Quaternion.identity);
        //itemUI.GetComponent<ShopItemUI>().Setup(item, this, index);
    }

    public void PurchaseItem(int index)
    {
        //Called only when triggered
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
