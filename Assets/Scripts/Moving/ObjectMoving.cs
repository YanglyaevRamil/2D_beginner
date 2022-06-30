using UnityEngine;

internal sealed class ObjectMoving : IMoving
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _speedMax;
    private Vector2 _speedTresh;

    public ObjectMoving(Rigidbody2D rigidbody2D, Vector2 speedMax, Vector2 speedTresh)
    {
        _rigidbody2D = rigidbody2D;
        _speedMax = speedMax;
        _speedTresh = speedTresh;
    }
    public void Moving(Vector2 acceleration) 
    {
        if (_rigidbody2D.velocity.magnitude <= _speedMax.magnitude)
            _rigidbody2D.AddForceAtPosition(acceleration, _rigidbody2D.position + acceleration.normalized, ForceMode2D.Force);
    }

    public void MovePosition(Vector2 velocity)
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + velocity);
    }

    public void UpdateSpeedMax(Vector2 newSpeedMax)
    {
        _speedMax += newSpeedMax;
    }
}