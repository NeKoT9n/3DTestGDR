using UnityEngine;
using DG.Tweening;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation = new Vector3(0,0,90);
    [SerializeField] private Vector3 _moving = new Vector3(0, 1, 0);
    private Tween _rotate;
    private Tween _move;
    private void OnEnable()
    {
        StartAnimation();
    }

    private void OnDisable()
    {
        StopAnimation();
    }
    private void StopAnimation()
    {
        _rotate.Kill();
        _move.Kill();
    }

    private void StartAnimation()
    {
        _move = transform.DOMove(_moving, 2f).SetRelative().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        _rotate = transform.DORotate(_rotation, 2f).SetRelative().SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
  

