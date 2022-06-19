using UnityEngine;

internal sealed class ObjectMoving : IMoving
{
    private Rigidbody2D _rigidbody2D;
    private float _speedMax;
    private float _acceleration;
    private float _speedTresh;

    public ObjectMoving(Rigidbody2D rigidbody2D, float speedMax, float acceleration, float speedTresh)
    {
        _rigidbody2D = rigidbody2D;
        _speedMax = speedMax;
        _acceleration = acceleration;
        _speedTresh = speedTresh;
    }

    public void Moving(Vector2 dir)
    {
        if (Mathf.Abs(dir.x) > _speedTresh)
        {
            if (Mathf.Abs(_rigidbody2D.velocity.x) <= _speedMax)
            {
                _rigidbody2D.velocity += dir * _acceleration;
            }
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
    }

    public void UpdateSpeedMax(float newSpeedMax)
    {
        _speedMax += newSpeedMax;
    }

    public void UpdateAcceleration(float newAcceleration)
    {
        _acceleration += newAcceleration;
    }
}