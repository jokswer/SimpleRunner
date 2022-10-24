using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private AudioSource coinSound;

    public int NumberOfCoins { get; private set; }

    void Start()
    {
        NumberOfCoins = Progress.Instance.Coins;
        UpdateText();
    }

    public void AddOne()
    {
        NumberOfCoins++;
        UpdateText();
        coinSound.Play();
    }

    public void RemoveCoins(int value)
    {
        NumberOfCoins -= value;
        UpdateText();
    }

    public void SaveToProgress()
    {
        Progress.Instance.Coins = NumberOfCoins;
    }

    private void UpdateText()
    {
        text.SetText(NumberOfCoins.ToString());
    }
}