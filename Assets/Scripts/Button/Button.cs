using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private Defender _defender;

    private UnityEngine.UI.Button _button;

    private void Start()
    {
        _button = GetComponent<UnityEngine.UI.Button>();
        var buttonTexts = _button.GetComponentsInChildren<Text>();
        buttonTexts[0].text = _defender.Name;
        buttonTexts[1].text = "Цена: " + _defender.Price;
        _button.image.sprite = _defender.Icon;
    }
}