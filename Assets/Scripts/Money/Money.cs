using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Money : MonoBehaviour
{
    private int _numberCoins = 20;
    private TMP_Text _text;

    public int NumberCoins => _numberCoins;

    private void Awake()
    {
        GlobalEvent.CoinAmountChanged.AddListener(TakeCoin);
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = _numberCoins.ToString();
    }

    private void TakeCoin()
    {
        _numberCoins++;
        _text.text = _numberCoins.ToString();
    }

    public void BuyDefender(int defenderPrice)
    {
        _numberCoins -= defenderPrice;
        _text.text = _numberCoins.ToString();
    }
}