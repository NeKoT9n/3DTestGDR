using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class AnimatedSlier : MonoBehaviour
{
    [SerializeField] float _maxValue = 100f;
    private Slider _slider;
   

    protected void Start()
    {
        _slider = GetComponent<Slider>();
        Init(_maxValue);
    }

    public void Init(float value)
    {
        _slider.maxValue = value;
    }


    public void UpdateValue(float value)
    {
        _slider.DOValue(value, 1.3f).SetEase(Ease.OutExpo);
    }
}
