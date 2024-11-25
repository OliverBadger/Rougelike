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

    public ShopItem() 
    {
        
    }
}