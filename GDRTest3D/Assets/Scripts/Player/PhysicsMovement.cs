using UnityEngine;

public class PhysicsMovement : IMovement
{
    private float _speed = 10f;

    private readonly Rigidbody _rigidbody;
    private readonly Transform _player;

    public PhysicsMovement(Rigidbody rigidbody, Transform player, float speed)
    {
        _rigidbody = rigidbody;
        _player = player;
        _speed = speed;  
    }

    public void Move(Vector2 direction)
    {
        var movePosition = new Vector3(direction.x, 0, direction.y).normalized;
        _rigidbody.MovePosition(_player.position + movePosition * _speed * Time.fixedDeltaTime);
    }

}
