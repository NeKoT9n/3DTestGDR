using UnityEngine;

public class WeaponPresenter : ItemView, ICollectable
{
    [field:SerializeField] public int Id { get; private set; }

    public void Collect(Player sender)
    {
        if (sender.TrySwitchWeapon(this) == false)
            return;

        gameObject.SetActive(false);
    }
}