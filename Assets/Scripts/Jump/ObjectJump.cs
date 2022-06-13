using UnityEngine;

internal sealed class ObjectJump : IJumping
{
    private Rigidbody2D _rigidbody2D;
    private float _jumpForce;

    public ObjectJump(Rigidbody2D rigidbody2D)
    {
        _rigidbody2D = rigidbody2D;
    }

    public void Jumping(float jumpForce)
    {
        _rigidbody2D.AddForce(Vector3.up * jumpForce);
    }

    public void UpdateJumpForce(float newJumpForce)
    {
        _jumpForce = newJumpForce;
    }
}