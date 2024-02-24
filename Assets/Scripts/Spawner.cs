using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _poolMaxSize = 5;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TargetPoint _targetPoint;
    [SerializeField] private float _spawnFrequency = 2f;
    [SerializeField] private Soldier _soldier;

    private List<Soldier> _pool = new();
    private bool _isSpawning = true;

    private void Awake() => FillPool();

    private void Start() => StartCoroutine(SpawnPeriodically());

    private void FillPool()
    {
        for (int i = 0; i < _poolMaxSize; i++)
        {
            Soldier soldier = Instantiate(_soldier);
            soldier.SetTarget(_targetPoint);
            soldier.Disable();
            _pool.Add(soldier);
        }
    }

    private void SpawnSoldier()
    {
        Soldier soldier = _pool.FirstOrDefault(currentSoldier => currentSoldier.gameObject.activeSelf == false);

        if (soldier != null)
        {
            soldier.transform.position = _spawnPoint.position;
            soldier.Enable();
        }
    }

    private IEnumerator SpawnPeriodically()
    {
        WaitForSeconds wait = new WaitForSeconds(_spawnFrequency);

        while (_isSpawning)
        {
            SpawnSoldier();
            yield return wait;
        }
    }
}