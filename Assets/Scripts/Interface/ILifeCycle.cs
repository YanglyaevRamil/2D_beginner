using UnityEngine;
public interface ILifeCycle
{
    public int Health { get; }
    void DamageTake(int damageTaken);
    public bool DeathCheck(out int h);
}

