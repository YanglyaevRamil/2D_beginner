using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [SerializeField]
    private CharacterSettings _characterSettings;

    public SpriteRenderer SpriteRendering { get { return _spriteRendering; } }
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
    public CircleCollider2D CircleCollider2D { get { return _circleCollider2D; } }

    private SpriteRenderer _spriteRendering;
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _circleCollider2D;

    private void OnEnable()
    {
        _spriteRendering = gameObject.GetComponent<SpriteRenderer>();
        if (_spriteRendering == null)
        {
            var sr = gameObject.AddComponent<SpriteRenderer>();
            sr.flipX = _characterSettings.FlipX;
            sr.flipY = _characterSettings.FlipY;
            sr.drawMode = _characterSettings.SpriteDrawMode;
            sr.maskInteraction = _characterSettings.SpriteMaskInteraction;
            sr.spriteSortPoint = _characterSettings.SpriteSortPoint;
            sr.sortingOrder = _characterSettings.SortingOrder;

            _spriteRendering = sr;
        }

        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null)
        {
            var rb = gameObject.AddComponent<Rigidbody2D>();
            rb.bodyType = _characterSettings.RigidbodyType2D;
            rb.simulated = _characterSettings.Sumulated;
            rb.useAutoMass = _characterSettings.UseAutoMass;
            if(rb.useAutoMass = (_characterSettings.UseAutoMass))
            {
                rb.mass = _characterSettings.Mass;
                rb.drag = _characterSettings.LinearDrag;
                rb.angularDrag = _characterSettings.AngularDrag;
                rb.gravityScale = _characterSettings.GravityScale;
            }
            rb.collisionDetectionMode = _characterSettings.CollisionDetectionMode2D;
            rb.sleepMode = _characterSettings.RigidbodySleepMode2D;
            rb.interpolation = _characterSettings.RigidbodyInterpolation2D;
            rb.constraints = _characterSettings.RigidbodyConstraints2D;

            _rigidbody2D = rb;
        }

        _circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        if (_circleCollider2D == null)
        {
            var cc = gameObject.AddComponent<CircleCollider2D>();
            cc.isTrigger = _characterSettings.IsTrigger;
            cc.usedByEffector = _characterSettings.UsedByEffector;
            cc.offset = _characterSettings.Offset;
            cc.radius = _characterSettings.Radius;

            _circleCollider2D = cc;
        }
    }
}