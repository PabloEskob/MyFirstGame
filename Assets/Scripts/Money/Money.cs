using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Money : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private int _numberCoins = 20;
    private TMP_Text _text;

    public int NumberCoins => _numberCoins;

    private void OnEnable()
    {
        _coin.CoinAmountChanged += TakeCoin;
    }

    private void OnDisable()
    {
        _coin.CoinAmountChanged -= TakeCoin;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = _numberCoins.ToString();
    }

    public void BuyDefender(int defenderPrice)
    {
        _numberCoins -= defenderPrice;
        _text.text = _numberCoins.ToString();
    }

    private void TakeCoin()
    {
        Debug.Log("dsa");
        _numberCoins += 1;
        _text.text = _numberCoins.ToString();
    }
}