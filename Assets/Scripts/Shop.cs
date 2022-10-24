using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager;

    private PlayerModifier _playerModifier;

    void Start()
    {
        _playerModifier = FindObjectOfType<PlayerModifier>();
    }

    public void BuyWidth()
    {
        if (coinManager.NumberOfCoins >= 20)
        {
            coinManager.RemoveCoins(20);
            Progress.Instance.Coins = coinManager.NumberOfCoins;
            Progress.Instance.Width += 25;
            _playerModifier.SetWidth(Progress.Instance.Width);
        }
    }

    public void BuyHeight()
    {
        if (coinManager.NumberOfCoins >= 20)
        {
            coinManager.RemoveCoins(20);
            Progress.Instance.Coins = coinManager.NumberOfCoins;
            Progress.Instance.Height += 25;
            _playerModifier.SetHeight(Progress.Instance.Height);
        }
    }
}
