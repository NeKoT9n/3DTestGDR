using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinHendler : MonoBehaviour
{
    private int _collectedCount = 0;
    private List<Coin> _coins = new List<Coin>();
    public List<Coin> Coins => _coins;
    public Action<int> CollectedCountChanged;

    public void Add(Coin coin)
    {
        _coins.Add(coin);
        coin.Collected += OnCollect;
    }

    private void OnCollect(Coin coin)
    {
        _collectedCount++;
        CollectedCountChanged?.Invoke(_collectedCount);
        _coins.Remove(coin);
    }
}
