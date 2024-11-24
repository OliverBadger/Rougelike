using UnityEngine;

public enum Rarity
{
    common,
    uncommon,
    rare,
    epic,
    legendary
}

[CreateAssetMenu(fileName = "NewShopItem", menuName = "Shop/Item")]
public class ShopItem : ScriptableObject
{
    public string itemName;
    public Rarity rarity;
    public GameObject prefab;
    public int cost; // Value of the item
    public int bonusDamage;
    public int bonusHealth;
    public int bonusSpeed;
    public string teeth;


    //private GameItem GetRandomItem()
    //{
    //    int totalWeight = 0;

    //    foreach (var item in allItems)
    //    {
    //        totalWeight += GetRarityWeight(item.rarity);
    //    }

    //    int randomValue = Random.Range(0, totalWeight);
    //    int runningSum = 0;

    //    foreach (var item in allItems)
    //    {
    //        runningSum += GetRarityWeight(item.rarity);
    //        if (randomValue < runningSum)
    //        {
    //            return item;
    //        }
    //    }

    //    return allItems[0]; // Default fallback
    //}

    //private int GetRarityWeight(Rarity rarity)
    //{
    //    switch (rarity)
    //    {
    //        case Rarity.common: return 50;
    //        case Rarity.uncommon: return 30;
    //        case Rarity.rare: return 15;
    //        case Rarity.epic: return 4;
    //        case Rarity.legendary: return 1;
    //        default: return 0;
    //    }
    //}
}