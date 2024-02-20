using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private Tank _prefab;
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private List<ControlPoint> _controlPoints;

    private int _currentControlPoint = 0;

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _controlPoints[_currentControlPoint].transform.position, _moveSpeed * Time.deltaTime);
        transform.LookAt(_controlPoints[_currentControlPoint].transform.position);

        if (transform.position == _controlPoints[_currentControlPoint].transform.position)
            ChangeControlPoint();
    }

    private void ChangeControlPoint()
    {
        _currentControlPoint++;

        if (_currentControlPoint >= _controlPoints.Count)
            _currentControlPoint = 0;
    }

    private void Update()
    {
        Move();
    }
}