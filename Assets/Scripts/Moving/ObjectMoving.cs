using UnityEngine;

internal sealed class ObjectMoving : IMoving
{
    private Rigidbody2D _rigidbody2D;
    private float _speed;

    public ObjectMoving(Rigidbody2D rigidbody2D, float speed)
    {
        _rigidbody2D = rigidbody2D;
        _speed = speed;
    }

    public void Moving(Vector2 dir)
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + dir * _speed);
    }

    public void UpdateSped(float d)
    {
        _speed += d;
    }
}