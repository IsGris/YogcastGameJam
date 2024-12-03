using UnityEngine;
public enum ShopItem
{
    Fuel,
    Engine,
    Precision
}

[CreateAssetMenu(fileName = "ShopUpgradeCosts", menuName = "Scriptable Objects/ShopUpgradeCosts")]
public class ShopUpgradeCosts : ScriptableObject
{
    public int[] fuelCosts = new int[] { 10 };
    public int[] engineCosts = new int[] { 10 };
    public int[] precisionCosts = new int[] { 10 };
    public int getNextCost(ShopItem item, int currentUpgradeLevel)
    {
        switch (item)
        {
            case ShopItem.Fuel:
                if (currentUpgradeLevel > fuelCosts.Length - 1)
                    return fuelCosts[^1];
                else
                    return fuelCosts[currentUpgradeLevel];
            case ShopItem.Engine:
                if (currentUpgradeLevel > engineCosts.Length - 1)
                    return engineCosts[^1];
                else
                    return engineCosts[currentUpgradeLevel];
            case ShopItem.Precision:
                if (currentUpgradeLevel > precisionCosts.Length - 1)
                    return precisionCosts[^1];
                else
                    return precisionCosts[currentUpgradeLevel];
        }
        
        Debug.LogError($"ShopItem {item} not processed in getNextCost in ShopUpgradeCosts class");
        return 0;
    }
}
