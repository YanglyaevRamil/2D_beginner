using UnityEngine;

internal sealed class ObjectJump : IJumping
{
    private Rigidbody2D _rigidbody2D;

    public ObjectJump(Rigidbody2D rigidbody2D)
    {
        _rigidbody2D = rigidbody2D;
    }

    public void Jumping(Vector2 jumpForce)
    {
        _rigidbody2D.AddForce(jumpForce);
    }
}