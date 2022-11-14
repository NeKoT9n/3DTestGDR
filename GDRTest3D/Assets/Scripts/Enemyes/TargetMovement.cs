using UnityEngine;

class TargetMovement : IMovement
{
    private float _speed;
    private Transform _transform;

    public TargetMovement(Transform player, float speed)
    {
        _transform = player;
        _speed = speed;

    }
    public void Move(Vector2 direction)
    {
        var step = _speed * Time.deltaTime;
        _transform.position = Vector3.MoveTowards(_transform.position, new Vector3(direction.x, _transform.position.y, direction.y), step);
    }
}

