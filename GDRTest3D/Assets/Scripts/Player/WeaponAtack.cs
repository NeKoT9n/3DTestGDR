
class WeaponAtack : IAtack
{
    private WeaponHandler _weapons;

    public WeaponAtack(WeaponHandler weapons)
    {
        _weapons = weapons;
    }

    public void Atack()
    {
       _weapons.CurrentWeapon.Shoot();
    }
}

