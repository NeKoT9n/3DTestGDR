using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform _firePoint;
    [SerializeField] private Transform _view;
    [SerializeField] protected float _rangeOffset = 1f;
    [SerializeField] protected float _directionOffset = 1f;
    [SerializeField] protected float _damage = 50f;
    [SerializeField] private float _atackTime = 1f;
    [SerializeField] private bool _isMelee = true;
    [field:SerializeField] public int Id { get; private set; }
    public float AtackTime => _atackTime;
    public bool IsMelee => _isMelee;

    public Action Killed;

    private void OnDisable()
    {
        _firePoint.gameObject.SetActive(false);
        _view.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _firePoint.gameObject.SetActive(true);
        _view.gameObject.SetActive(true);
    }
    public virtual void Shoot()
    {
        Vector3 shootPosition = new Vector3(_firePoint.position.x, _firePoint.position.y + 1, _firePoint.position.z);
        Vector3 size = new Vector3(_firePoint.lossyScale.x / 2 * _rangeOffset, 3, _firePoint.lossyScale.y / 2 * _directionOffset);

        var hits = Physics.BoxCastAll(shootPosition, size, transform.forward, transform.rotation, size.z);

        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.TryGetComponent(out IDamageble enemy))
            {
                enemy.ApplyDamage(_damage, this);
            }
        }
    }
}
