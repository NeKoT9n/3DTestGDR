using UnityEngine;

public class EntityAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private readonly string _move = "run";
    private readonly string _melee = "atack";
    private readonly string _shoot = "shoot";

    private void Start()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();

        StopAll();
    }

    private void StopAll()
    {
        _animator.SetBool(_move, false);
        _animator.SetBool(_melee, false);
        _animator.SetBool(_shoot, false);
    }
    public void Move(bool isMoving)
    {
        _animator.SetBool(_move, isMoving);
    }

    public void Idle()
    {
        StopAll();
    }

    public void Melee(bool isAtacking)
    {
        _animator.SetBool(_melee, isAtacking);
    }

    public void Shoot(bool isAtacking)
    {
        _animator.SetBool(_shoot, isAtacking);
    }

    public void StopAtacking()
    {
        _animator.SetBool(_shoot, false);
        _animator.SetBool(_melee, false);
    }
}
