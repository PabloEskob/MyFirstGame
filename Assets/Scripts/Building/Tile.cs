using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tile : MonoBehaviour
{
    [SerializeField] private Color _intialColor;
    [SerializeField] private Color _resolutionColor;
    [SerializeField] private Color _forBiddingColor;

    private Building _building;
    private bool _isBuilt = true;
    private SpriteRenderer _renderer;

    public bool IsBuilt => _isBuilt;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void AddBuilding(Building building)
    {
       _building = building.GetComponent<Building>();
    }

    private void OnMouseEnter()
    {
        _renderer.color = _isBuilt switch
        {
            true => _resolutionColor,
            false => _forBiddingColor
        };
    }

    private void OnMouseExit()
    {
        _renderer.color = _intialColor;
    }

    private void OnMouseDown()
    {
        if (_building.PutDefender(this))
        {
            _isBuilt = false;
        }
    }
}