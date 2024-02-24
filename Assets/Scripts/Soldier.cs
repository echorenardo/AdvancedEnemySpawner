using System.Collections;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField, Range(0f, 4f)] private float _maxMoveSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _triggerDistance = 4f;

    private TargetPoint _targetPoint;

    private void OnEnable()
    {
        if (_targetPoint != null)
            StartCoroutine(GoToTarget());
    }

    public void Enable() => gameObject.SetActive(true);

    public void Disable() => gameObject.SetActive(false);

    public void SetTarget(TargetPoint targetPoint) => _targetPoint = targetPoint;

    private IEnumerator GoToTarget()
    {
        float moveSpeed;

        while ((transform.position - _targetPoint.transform.position).magnitude > _triggerDistance)
        {
            moveSpeed = (_targetPoint.transform.position - transform.position).magnitude;

            if (moveSpeed > _maxMoveSpeed)
                moveSpeed = _maxMoveSpeed;

            _animator.SetFloat(Speed, moveSpeed);

            transform.LookAt(_targetPoint.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint.transform.position, moveSpeed * Time.deltaTime);
            yield return null;
        }

        Disable();
    }
}