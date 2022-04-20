using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonPress : MonoBehaviour
{
    [SerializeField] private Defender _defender;
    [SerializeField] private Text _buttonTextName;
    [SerializeField] private Text _buttonTextPrice;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _buttonTextName.text = _defender.Name;
        _buttonTextPrice.text = "Цена: " + _defender.Price;
        _button.image.sprite = _defender.Icon;
    }
}