using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    public Text itemNameText;
    public Image rarityImage;
    public Text costText;
    public Button purchaseButton;

    private ShopItem item;
    private int itemIndex;
    private ShopManager shopManager;

    public void Setup(ShopItem newItem, ShopManager manager, int index)
    {
        item = newItem;
        shopManager = manager;
        itemIndex = index;

        // Update UI
        itemNameText.text = item.itemName;
        costText.text = $"Cost: {item.cost}";
        rarityImage.color = GetRarityColor(item.rarity);

        // Add listener to purchase button
        purchaseButton.onClick.AddListener(() => shopManager.PurchaseItem(itemIndex));
    }

    private Color GetRarityColor(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.common: return Color.gray;
            case Rarity.uncommon: return Color.green;
            case Rarity.rare: return Color.blue;
            case Rarity.epic: return Color.magenta;
            case Rarity.legendary: return Color.yellow;
            default: return Color.white;
        }
    }
}
