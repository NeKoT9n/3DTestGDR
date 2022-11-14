using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble, IMovement , IAtack
{

    [SerializeField] private EnemyHealthBar _healthView;
    [SerializeField, Range(0f, 20f)] private float _speed = 4f;
    [SerializeField] private WeaponHandler _weapons;
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private EntityAnimation _animator;
    [SerializeField] private float _LvlUpReward = 0.2f;

    private IMovement _movement;
    private IAtack _atack;
    private Health _health;
    private LvlUp _lvl;

    private bool _canAtack = false;
    private bool _canMove = true;

    public Action<Enemy> Died;

    private void Start()
    {
        _health = new Health(_maxHealth, _healthView);
        _health.Ended += OnDied;
        _movement = new TargetMovement(transform, _speed);
        _weapons.Init();
        _atack = new WeaponAtack(_weapons);

        _lvl = new LvlUp(transform, _LvlUpReward);

        foreach (var weapon in _weapons.Weapons)
            weapon.Killed += LvlUp;
    }

    public void LvlUp()
    {
        _lvl.Up();
    }


    private void OnDied()
    {
        gameObject.SetActive(false);
        Died?.Invoke(this);
    }

    public void ApplyDamage(float damage, Weapon sender)
    {
        if (_weapons.CurrentWeapon == sender)
            return;

        _health.ApplyDamage(damage, sender);
    }

    public void Move(Vector2 direction)
    {
        if(_canMove == false)
        {
            _animator.Move(_canMove);
            return;
        }

        _animator.Move(_canMove);
        _movement.Move(direction);
        _canAtack = true;
        RotateTo(direction);
    }
    private void RotateTo(Vector2 to)
    {
        Vector3 targetDirection =new Vector3(to.x, transform.position.y, to.y) - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime * 2, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
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

        _animator.Melee(true);


        float duration = _weapons.CurrentWeapon.AtackTime;
        yield return new WaitForSeconds(duration);

        _atack.Atack();

        yield return new WaitForSeconds(duration / 2);

        _animator.Melee(false);
        _canMove = true;

    }
}
