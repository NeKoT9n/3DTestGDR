using UnityEngine;
using DG.Tweening;

public class LvlUp 
{
    private Transform _target;
    private float _reward;
    private float _current;
    private Tween _upTween;


    public LvlUp(Transform target, float reward)
    {
        _target = target;
        _reward = reward;
        _current = _target.localScale.x;
    }

    public void Up()
    {
        _current += _reward;

        _upTween.Kill();
        _upTween = _target.DOScale(new Vector3(_current, _current, _current), 3).SetEase(Ease.OutBack);
        _target.localPosition += new Vector3(0, _reward, 0);
    }

    ~LvlUp()
    {
        _upTween.Kill();
    }
}
