using UnityEngine;

internal sealed class ObjectLifeCycle : ILifeCycle
{
    public int Health { get { return _health; } }
    private int _health;

    public ObjectLifeCycle(int health)
    {
        _health = health;
    }

    public void DamageTake(int damageTaken)
    {
        _health -= damageTaken;
    }

    public bool DeathCheck(out int h)
    {
        h = _health;
        if (_health <= 0)
        {
            _health = 0;
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void UpdateHealth(int d)
    {
        _health += d;
    }
}