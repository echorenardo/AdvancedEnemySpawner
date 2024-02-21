using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _poolMaxSize = 5;
    [SerializeField] private Spawner _prefab;
    [SerializeField] private TargetPoint _targetPoint;
    [SerializeField] private float _spawnFrequency = 2f;
    [SerializeField] private Soldier _soldier;

    private List<Soldier> _pool = new();

    private void Start() => InvokeRepeating(nameof(SpawnSoldier), 0f, _spawnFrequency);

    private void FillPool()
    {
        for (int i = 0; i < _poolMaxSize; i++)
        {
            Soldier soldier = Instantiate(_soldier);
            soldier.SetTarget(_targetPoint);
            soldier.ChangeState(false);
            _pool.Add(soldier);
        }
    }

    private void SpawnSoldier()
    {
        Soldier soldier = _pool.FirstOrDefault(currentSoldier => currentSoldier.gameObject.activeSelf == false);

        if (soldier != null)
        {
            soldier.transform.position = _prefab.transform.position;
            soldier.ChangeState(true);
        }
    }

    private void Awake() => FillPool();
}