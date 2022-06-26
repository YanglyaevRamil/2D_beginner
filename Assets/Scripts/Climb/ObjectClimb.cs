using UnityEngine;

internal sealed class ObjectClimb : IClimb
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _speed;
    private float _climbTresh;
    public ObjectClimb(Rigidbody2D rigidbody2D, Vector2 speed, float climbTresh)
    {
        _rigidbody2D = rigidbody2D;
        _speed = speed;
        _climbTresh = climbTresh;
    }

    public void Climb(float dir)
    {
        if (Mathf.Abs(dir) >= _climbTresh)
            _rigidbody2D.velocity = new Vector2(0, _speed.y * dir);
        else
            _rigidbody2D.velocity = new Vector2(0, 0);
    }

    public void UpdateSped(Vector2 newSpeed)
    {
        _speed += newSpeed;
    }

}