using UnityEngine;

internal sealed class ObjectMoving : IMoving
{
    private Rigidbody2D _rigidbody2D;
    private float _speedMax;
    private float _acceleration;

    public ObjectMoving(Rigidbody2D rigidbody2D, float speedMax, float acceleration)
    {
        _rigidbody2D = rigidbody2D;
        _speedMax = speedMax;
        _acceleration = acceleration;
    }

    public void Moving(Vector2 dir)
    {
        if (Mathf.Abs(_rigidbody2D.velocity.x) <= _speedMax)
            _rigidbody2D.velocity += dir * _acceleration;
    }

    public void UpdateSpedMax(float newSpeedMax)
    {
        _speedMax += newSpeedMax;
    }

    public void UpdateAcceleration(float newAcceleration)
    {
        _acceleration += newAcceleration;
    }
}