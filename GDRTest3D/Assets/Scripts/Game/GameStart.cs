using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private EnemyHendler _enemies;
    [SerializeField] private CoinHendler _coins;
    [SerializeField] private Player _player;
    [SerializeField] private GameUI _UI;

    private void Start()
    {
        _UI.Init(_coins, _enemies, _player);
    }


}
