
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHendler : MonoBehaviour
{
    private List<Enemy> _enemies = new List<Enemy>();

    public Action AllEnemyDied;
    public Action<int> EnemyCountChanched;

    private void Start()
    {
        var enemies = GetComponentsInChildren<Enemy>();

        if (enemies.Length == 0)
            throw new Exception("No enemies on scene");

        _enemies = enemies.ToList();
        foreach(Enemy enemy in _enemies)
        {
            enemy.Died += Remove;
        }

        EnemyCountChanched?.Invoke(_enemies.Count);
    }
    public void Remove(Enemy enemy)
    {
        _enemies.Remove(enemy);

        EnemyCountChanched?.Invoke(_enemies.Count);
        if (_enemies.Count == 0)
            AllEnemyDied?.Invoke();
    }
}

