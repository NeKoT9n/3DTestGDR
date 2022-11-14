using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class WeaponHandler : MonoBehaviour
{
    private List<Weapon> _weapons;

    public Weapon CurrentWeapon { get; private set; }
    public List<Weapon> Weapons => _weapons;

    public void Init()
    {
        var weapons = GetComponentsInChildren<Weapon>();

        if (weapons.Length == 0)
            throw new InvalidOperationException("There are no weapons");

        _weapons = weapons.ToList();

        CurrentWeapon = weapons[UnityEngine.Random.Range(0, _weapons.Count)];

        foreach (Weapon _weapon in _weapons)
        {
            if (_weapon == CurrentWeapon)
            {
                _weapon.gameObject.SetActive(true);
                continue;
            }

            _weapon.gameObject.SetActive(false);
        }
    }

    private void Set(Weapon weapon)
    {
        CurrentWeapon.gameObject.SetActive(false);
        weapon.gameObject.SetActive(true);
        CurrentWeapon = weapon;
    }

    public bool TrySwitch(WeaponPresenter weapon)
    {
        if (weapon.Id == CurrentWeapon.Id)
            return false;

        foreach(var wepon in _weapons)
        {
            if (weapon.Id == wepon.Id)
                Set(wepon);
        }
        return true;
    }
}

