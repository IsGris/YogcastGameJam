using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    void Awake()
    {
        InitializePlayerPrefs();
    }

    void InitializePlayerPrefs()
    {
        TryCreatePlayerPref("playerMoney", 0);
        TryCreatePlayerPref($"{ShopItem.Fuel}currentLevel", 0);
        TryCreatePlayerPref($"{ShopItem.Engine}currentLevel", 0);
        TryCreatePlayerPref($"{ShopItem.Precision}currentLevel", 0);
    }

    void TryCreatePlayerPref(string name, int value)
    {
        if (!PlayerPrefs.HasKey(name))
            PlayerPrefs.SetInt(name, value);
    }
}
