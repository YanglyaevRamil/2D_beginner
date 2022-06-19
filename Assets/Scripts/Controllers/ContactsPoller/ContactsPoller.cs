using UnityEngine;

internal sealed class ContactsPoller : IExecute
{
    private float _collisionThresh;
    private ContactPoint2D[] _contacts = new ContactPoint2D[10];
    private int _contactsCount;
    private readonly Collider2D _collider2D;
    public bool IsGrounded { get; private set; }
    public bool HasLeftContacts { get; private set; }
    public bool HasRightContacts { get; private set; }
    public bool IsFly { get; private set; }  
    public ContactsPoller(Collider2D collider2D, float collisionThresh)
    {
        _collider2D = collider2D;
        _collisionThresh = collisionThresh;
    }

    public void Execute(float deltaTime)
    {
        IsGrounded = false;
        HasLeftContacts = false;
        HasRightContacts = false;
        IsFly = false;
        _contactsCount = _collider2D.GetContacts(_contacts);

        if (_contactsCount == 0)
        {
            IsFly = true;
        }

        for (int i = 0; i < _contactsCount; i++)
        {
            var normal = _contacts[i].normal;
            var rigidBody = _contacts[i].rigidbody;
            var collider = _contacts[i].collider;
            if (normal.y > _collisionThresh) IsGrounded = true;

            if (normal.x > _collisionThresh && rigidBody == null && !(collider is PolygonCollider2D))
                HasLeftContacts = true;
            if (normal.x < -_collisionThresh && rigidBody == null && !(collider is PolygonCollider2D))
                HasRightContacts = true;
        }
    }
}