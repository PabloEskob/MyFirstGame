using UnityEngine;

[CreateAssetMenu(fileName = "new Defender", menuName = "Character/Create new Defender")]
public class Defender : Character
{
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Unit _unitPref;

    public int Price => _price;
    public string Name => _name;
    public Sprite Icon => _icon;
    public Unit UnitPref => _unitPref;
}