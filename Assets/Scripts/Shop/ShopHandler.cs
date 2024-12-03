using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    [SerializeField] private Button buyFuel, buyEngine, buyPrecision;
    [SerializeField] private TMP_Text fuelCost, engineCost, precisionCost;
    [SerializeField] private TMP_Text money;
    [SerializeField] protected ShopUpgradeCosts allCosts;

    void Start()
    {
        buyFuel.onClick.AddListener(() => TryBuyItem(ShopItem.Fuel));
        buyEngine.onClick.AddListener(() => TryBuyItem(ShopItem.Engine));
        buyPrecision.onClick.AddListener(() => TryBuyItem(ShopItem.Precision));
        GameData.onUpgradeLevelChange += ChangeUpgradeCostText;
        GameData.onPlayerMoneyChange += ChangeMoneyText;
    }

    private void ChangeMoneyText(int newValue)
    {
        money.text = newValue + "$";
    }

    private void ChangeUpgradeCostText(ShopItem upgrade, int newValue)
    {
        switch (upgrade)
        {
            case ShopItem.Fuel:
                fuelCost.text = allCosts.getNextCost(upgrade, newValue) + "$";
                break;
            case ShopItem.Engine:
                engineCost.text = allCosts.getNextCost(upgrade, newValue) + "$";
                break;
            case ShopItem.Precision:
                precisionCost.text = allCosts.getNextCost(upgrade, newValue) + "$";
                break;
        }
    }

    public void TryBuyItem(ShopItem ItemToBuy)
    {
        var cost = allCosts.getNextCost(ItemToBuy, GameData.getUpgradeCurrentLevel(ItemToBuy));
        if (cost > GameData.playerMoney)
        {
            // Cant buy item not enough money
            return;
        }

        GameData.playerMoney -= cost;
    }
}