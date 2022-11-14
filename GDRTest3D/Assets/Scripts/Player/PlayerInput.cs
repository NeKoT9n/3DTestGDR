using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Player _player;

    private Vector2 _moveDirection;


    private void Update()
    {
        _moveDirection = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        if (_moveDirection.x == 0 && _moveDirection.y == 0)
        {
            _player.Atack();
        }
                   
    }

    private void FixedUpdate()
    {
        _player.Move(_moveDirection);
    }




}
