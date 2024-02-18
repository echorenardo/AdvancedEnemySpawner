using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Tank _prefab;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private List<ControlPoint> _controlPoints;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}