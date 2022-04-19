using Unity.Mathematics;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Money _money;

    private GameObject _defender;
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
                Destroy(_defender);
            }

            _defender = Instantiate(defenderPrefab.Prefab);
            RegulateVisibility(false);
        }
    }

    public bool PutDefender(Tile tile)
    {
        if (_defender != null && tile.IsBuilt)
        {
            RegulateVisibility(true);
            Instantiate(_defender, tile.transform.position, quaternion.identity);
            _money.BuyDefender(_defenderPrice);
            Destroy(_defender);
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

    private void RegulateVisibility(bool result)
    {
        _defender.GetComponent<Shoot>().enabled = result;
        _defender.GetComponent<BoxCollider2D>().enabled = result;
    }
}