using UnityEngine;

public class EnemyHealthBar : AnimatedSlier
{
    private Camera _mainCamera;

    protected new void Start()
    {
        base.Start();
        _mainCamera = Camera.main;
    }
    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _mainCamera.transform.position);
    }
}

