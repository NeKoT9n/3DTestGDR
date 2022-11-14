using System;

public class Health : IDamageble
{
    private readonly float _maxHelth;
    private float _currentHealth;
    private AnimatedSlier _healthView;

    public Action Ended;

    public Health(float maxHelth, AnimatedSlier healthBar)
    {
        _maxHelth = maxHelth;
        _currentHealth = _maxHelth;
        _healthView = healthBar;
    }
    public void ApplyDamage(float damage, Weapon sender)
    {
        _currentHealth -= damage;
        _healthView.UpdateValue(_currentHealth);

        if (_currentHealth <= 0)
        {
            Destroy();
            sender.Killed?.Invoke();
        }
    }

    private void Destroy()
    {
        Ended?.Invoke();
    }
}

