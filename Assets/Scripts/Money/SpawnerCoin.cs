using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerCoin : CoinPool
{
   [SerializeField] private Coin coinPrefab;
   [SerializeField] private float _secondsBetweenSpawn;
   [SerializeField] private Transform _spawnPoint;
   [SerializeField] private float _scattering;

   private float _elapserTime=0;

   private void Start()
   {
      Init(coinPrefab);
   }

   private void Update()
   {
      _elapserTime += Time.deltaTime;

      if (_elapserTime>=_secondsBetweenSpawn)
      {
         if (TryGetObject(out Coin coin))
         {
            _elapserTime = 0;
            Vector3 offset = new Vector2( Random.Range(-_scattering, _scattering),0);
            SetCoin(coin,_spawnPoint.position+offset);
         }
      }
   }

   private void SetCoin(Coin coin,Vector3 spawnPoint)
   {
      coin.SetActive(true);
      coin.transform.position = spawnPoint;
   }
}
