using UnityEngine;

[CreateAssetMenu(fileName = "new Defender", menuName = "Character/Create new Defender")]
public class Defender : Character
{
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public int Price => _price;
    public string Name => _name;
    public Sprite Icon => _icon;
}