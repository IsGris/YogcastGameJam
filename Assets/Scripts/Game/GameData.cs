using UnityEngine;
using System;

public class GameData : MonoBehaviour
{
    public static int getUpgradeCurrentLevel(ShopItem item) => PlayerPrefs.GetInt($"{item}currentLevel");

    public static void setUpgradeCurrentLevel(ShopItem item, int newValue)
    {
        PlayerPrefs.SetInt($"{item}currentLevel", newValue);
        onUpgradeLevelChange?.Invoke(item, newValue);
    }

    // 1st argument - newMoneyValue
    public static event Action<int> onPlayerMoneyChange;
    public static event Action<ShopItem, int> onUpgradeLevelChange;

    public static int playerMoney
    {
        get => PlayerPrefs.GetInt("playerMoney");
        set
        {
            PlayerPrefs.SetInt("playerMoney", value);
            onPlayerMoneyChange?.Invoke(value);
        }
    }
}
