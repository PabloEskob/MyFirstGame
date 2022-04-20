using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _container;
    [SerializeField] private int _capacity;

    private List<Coin> _pool = new List<Coin>();

    protected void Init(Coin prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            Coin spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Coin result)
    {
        result = _pool.FirstOrDefault(p => p.ActiveSelf == false);
        return result != null;
    }
}