using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [SerializeField] private Text _coinsCount;
    public void Show(int coinsCount)
    {
        _coinsCount.text = coinsCount.ToString();
        gameObject.SetActive(true);
    }
}