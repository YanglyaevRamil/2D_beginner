using UnityEngine;

public sealed class Health 
{
    public int HealthNow { get { return _healthNow; } }

    private int _healthMax;
    private int _healthNow;

    public Health(int healthMax)
    {
        _healthMax = healthMax;
        _healthNow = _healthMax;
    }

    public void SetHeltNow(int healthNow)
    {
        _healthNow = healthNow;
    }

    public void SetHeltMax(int healthMax)
    {
        _healthMax = healthMax;
    }
}