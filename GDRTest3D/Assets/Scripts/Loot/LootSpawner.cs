using System.Collections;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    [SerializeField] private Transform _ground;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private WeaponPresenter[] _weaponPrefab;
    [SerializeField] private CoinHendler _coinHendler;
    [SerializeField] private float _spawnDuration;
    [SerializeField] private int _maxCoins;


    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    private IEnumerator StartSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDuration);

            SpawnCoin();

            if (Random.Range(0, 5) == 0)
                SpawnWeapon();
                                          
        }

    }

    private void SpawnCoin() {

        if (_coinHendler.Coins.Count >= _maxCoins)
            return;
        var position = GetRandomPoint();
        var coin = Instantiate(_coinPrefab, position, _coinPrefab.transform.rotation, _coinHendler.transform);
        _coinHendler.Add(coin);
    }

    private void SpawnWeapon()
    {
        var position = GetRandomPoint();
        var weapon = _weaponPrefab[Random.Range(0, _weaponPrefab.Length)];
        Instantiate(weapon, position, weapon.transform.rotation);

    }

    private Vector3 GetRandomPoint()
    {
        float x = Random.Range(_ground.position.x - _ground.localScale.x * 5, _ground.position.x + _ground.localScale.x * 5);
        float y = Random.Range(_ground.position.y - _ground.localScale.z * 5, _ground.position.z + _ground.localScale.z * 5);
        return new Vector3(x, _ground.position.y + _coinPrefab.transform.localScale.z, y);
    }
}
