using UnityEngine;

public class LootBox : MonoBehaviour, IDamageble
{
    [SerializeField] private WeaponPresenter[] _weaponPrefabs;
    [SerializeField] CoinHendler _coinHendler;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _minCoins;
    [SerializeField] private int _maxCoins;



    public void ApplyDamage(float damage, Weapon sender)
    {
        for (int i = 0; i < Random.Range(_minCoins, _maxCoins); i++)
        {
            var coin = Instantiate(_coinPrefab, new Vector3(transform.position.x + Random.Range(-1f, 1f), transform.position.y + 0.5f, transform.position.z + Random.Range(-1f, 1f)), _coinPrefab.transform.rotation, _coinHendler.transform);
            _coinHendler.Add(coin);
        }

        var weapon = _weaponPrefabs[Random.Range(0, _weaponPrefabs.Length)];
            Instantiate(weapon, transform.position + new Vector3(0,0.5f, 0), weapon.transform.rotation);

        Destroy(gameObject);
    }

}
