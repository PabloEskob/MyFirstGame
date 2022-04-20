using Unity.Mathematics;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Money _money;

    private Unit _defender;
    private int _defenderPrice;

    private void Update()
    {
        FlyWithMouse();
    }

    public void TakeDefender(Defender defenderPrefab)
    {
        if (_money.NumberCoins >= defenderPrefab.Price)
        {
            _defenderPrice = defenderPrefab.Price;

            if (_defender != null)
            {
                Destroy(_defender.gameObject);
            }

            _defender = Instantiate(defenderPrefab.UnitPref);
            _defender.RegulateVisibility(false);
        }
    }

    public bool PutDefender(Tile tile)
    {
        if (_defender != null && tile.IsBuilt)
        {
            var newDefender = Instantiate(_defender, tile.transform.position, quaternion.identity);
            newDefender.RegulateVisibility(true);
            _money.BuyDefender(_defenderPrice);
            Destroy(_defender.gameObject);
            return true;
        }

        return false;
    }

    private void FlyWithMouse()
    {
        Vector2 mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (_defender != null)
        {
            int xPosition = Mathf.RoundToInt(mouseWorldPosition.x);
            int yPosition = Mathf.RoundToInt(mouseWorldPosition.y);
            _defender.transform.position = new Vector2(xPosition, yPosition);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(_defender);
        }
    }
}