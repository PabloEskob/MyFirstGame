using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private Defender _defender;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        var buttonTexts = _button.GetComponentsInChildren<Text>();
        buttonTexts[0].text = _defender.Name;
        buttonTexts[1].text = "Цена: " + _defender.Price;
        _button.image.sprite = _defender.Icon;
    }
}