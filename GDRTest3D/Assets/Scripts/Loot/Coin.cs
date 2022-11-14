using System;
using UnityEngine;


public class Coin : ItemView, ICollectable
{

    public Action<Coin> Collected;

    public void Collect(Player sender)
    {
        Collected?.Invoke(this);
        Destroy(gameObject);
    }



}
