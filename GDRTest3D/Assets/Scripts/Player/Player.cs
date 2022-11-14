using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IMovement, IDamageble, IAtack
{
    [SerializeField, Range(0f, 20f)] private float _speed = 4f;
    [SerializeField] private AnimatedSlier _healthView;
    [SerializeField] private WeaponHandler _weapons;
    [SerializeField] private float _maxHelth = 100f;
    [SerializeField] private float _LvlUpReward = 0.2f;
    [SerializeField] private EntityAnimation _animator;
    private IMovement _movement;
    private IAtack _atack;

    private Rigidbody _rigidbody;
    private Health _health;
    private LvlUp _lvl;

    private bool _canAtack = false;
    private bool _canMove = true;

    public Action Died;

    private void Start()
    {
        if (_weapons == null)
            _weapons = GetComponentInChildren<WeaponHandler>();
        _rigidbody = GetComponent<Rigidbody>();

        _weapons.Init();
        _movement = new PhysicsMovement(_rigidbody, transform, _speed);
        _atack = new WeaponAtack(_weapons);

        _lvl = new LvlUp(transform, _LvlUpReward);
        _health = new Health(_maxHelth, _healthView);
        _health.Ended += OnDied;


        foreach (var weapon in _weapons.Weapons)
            weapon.Killed += LvlUp;

    }

    private void OnDied()
    {
        gameObject.SetActive(false);
        Died?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ICollectable item))
        {
            item.Collect(this);
        }
    }

    public bool TrySwitchWeapon(WeaponPresenter weapon)
    {
        if (_weapons.TrySwitch(weapon) == false)
            return false;

        return true;
    }

    private void RotateTo(Vector2 to)
    {
        Vector3 direction = new Vector3(to.x, 0, to.y);
        Quaternion rotaion = Quaternion.Euler(direction);
        transform.rotation *= rotaion;
        _rigidbody.transform.forward = _rigidbody.transform.forward + direction;
    }

    private void LvlUp()
    {
        _lvl.Up();
    }


    public void Move(Vector2 direction)
    {
        if (direction == Vector2.zero || _canMove == false)
        {
            _animator.Move(false);
            return;
        }

        _movement.Move(direction);
        _animator.Move(true);
        RotateTo(direction);
        _canAtack = true;
    }

    public void Atack()
    {
        if (_canAtack == false)
            return;

        _canAtack = false;
        _canMove = false;

        StartCoroutine(AtackWithAnimation());

    }

    private IEnumerator AtackWithAnimation()
    {

        if (_weapons.CurrentWeapon.IsMelee)
            _animator.Melee(true);
        else
            _animator.Shoot(true);

        float duration = _weapons.CurrentWeapon.AtackTime;
        yield return new WaitForSeconds(duration);

        _atack.Atack();

        yield return new WaitForSeconds(duration / 2);

        _animator.StopAtacking();
        _canMove = true;

    }


    public void ApplyDamage(float damage, Weapon sender)
    {
        if (_weapons.CurrentWeapon == sender)
            return;

        _health.ApplyDamage(damage, sender);
    }




}
