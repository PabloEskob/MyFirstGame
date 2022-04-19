using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPointEnemy;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
        {
            return;
        }

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstatiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void InstatiateEnemy()
    {
        Random random = new Random();
        var randomPoint = random.Next(0, _spawnPointEnemy.Length);
        var randomTamplate = random.Next(0, _currentWave.Tamplate.Length);
        Instantiate(_currentWave.Tamplate[randomTamplate], _spawnPointEnemy[randomPoint].position, Quaternion.identity);
    }
}

[Serializable]
public class Wave
{
    public GameObject[] Tamplate;
    public float Delay;
    public int Count;
}