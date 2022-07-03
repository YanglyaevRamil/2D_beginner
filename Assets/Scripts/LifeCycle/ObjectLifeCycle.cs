
internal sealed class ObjectLifeCycle : ILifeCycle
{
    private Health _health;

    public ObjectLifeCycle(Health health)
    {
        _health = health;
    }
    
    public void DamageTake(int damageTaken)
    {
        _health.SetHeltNow(_health.HealthNow - damageTaken);
    }

    public bool DeathCheck()
    {
        if (_health.HealthNow <= 0)
        {
            _health.SetHeltNow(0);
            return true;
        }
        else
        {
            return false;
        }
        
    }

    public void UpdateHealthNow(int newHealth)
    {
        _health.SetHeltNow(newHealth);
    }

    public void UpdateHealthMax(int newHealth)
    {
        _health.SetHeltMax(newHealth);
    }
}