using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text _coins;
    [SerializeField] private Text _enemyesLeft;
    [SerializeField] private EndGamePanel _winPanel;
    [SerializeField] private EndGamePanel _losePanel;

    private CoinHendler _coinHendler;
    private EnemyHendler _enemyes;
    private Player _player;
    private int _coinsCount;

    public void Init(CoinHendler coins, EnemyHendler enemyes, Player player)
    {
        _coinHendler = coins;
        _enemyes = enemyes;
        _player = player;

        enemyes.AllEnemyDied += ShowWinPanel;
        enemyes.EnemyCountChanched += UpdateEnemyLeftCount;
        coins.CollectedCountChanged += UpdateCoins;
        player.Died += ShowLosePanel;


        _winPanel.gameObject.SetActive(false);
        _losePanel.gameObject.SetActive(false);
    }
    private void UpdateCoins(int count)
    {
        _coinsCount = count;
        _coins.text = count.ToString();
    }

    private void UpdateEnemyLeftCount(int count)
    {
        _enemyesLeft.text = count.ToString();
    }

    private void ShowLosePanel()
    {
        _losePanel.Show(_coinsCount);
    }

    private void ShowWinPanel()
    {
        _winPanel.Show(_coinsCount);
    }

}
