using UnityEngine;

public class PlayerResourcesHolder : MonoBehaviour
{
    private static PlayerResourcesHolder _instance;
    public static PlayerResourcesHolder Instance => _instance;

    public enum Resources
    {
        Coins
    }

    private int _coins;


    private void Start()
    {
        GamestagesFSM.Instance.FinishedChanged += SaveCoins;

        _coins = LoadCoins();
    }

    public void AddCoins(int value)
    {
        _coins += value;
    }

    private void OnEnable()
    {
        if (Instance == null)
            _instance = this;
    }

    private void OnDisable()
    {
        _instance = null;
        GamestagesFSM.Instance.FinishedChanged -= SaveCoins;
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt(Resources.Coins.ToString(), _coins);
    }

    private int LoadCoins()
    {
        return PlayerPrefs.GetInt(Resources.Coins.ToString());
    }
}