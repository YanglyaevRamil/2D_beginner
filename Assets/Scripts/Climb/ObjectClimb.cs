using UnityEngine;

internal sealed class ObjectClimb : IClimb
{
    private Rigidbody2D _rigidbody2D;
    private float _speed;
    private float _climbTresh;
    public ObjectClimb(Rigidbody2D rigidbody2D, float speed, float climbTresh)
    {
        _rigidbody2D = rigidbody2D;
        _speed = speed;
        _climbTresh = climbTresh;
    }

    public void Climb(float dir)
    {
        if (Mathf.Abs(dir) >= _climbTresh)
            _rigidbody2D.velocity = new Vector2(0, _speed * dir);
        else
            _rigidbody2D.velocity = new Vector2(0, 0);
    }

    public void UpdateSped(float newSpeed)
    {
        _speed += newSpeed;
    }

}