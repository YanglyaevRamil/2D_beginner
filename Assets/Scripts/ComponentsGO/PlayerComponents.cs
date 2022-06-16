using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [SerializeField]
    CharacterSettings _characterSettings;

    private SpriteRenderer _spriteRendering;
    private Rigidbody2D _rigidbody2D;
    private CircleCollider2D _circleCollider2D;

    private void OnEnable()
    {
        if (!gameObject.GetComponent<SpriteRenderer>())
        {
            var sr = gameObject.AddComponent<SpriteRenderer>();
            sr.flipX = _characterSettings.FlipX;
            sr.flipY = _characterSettings.FlipY;
            sr.drawMode = _characterSettings.SpriteDrawMode;
            sr.maskInteraction = _characterSettings.SpriteMaskInteraction;
            sr.spriteSortPoint = _characterSettings.SpriteSortPoint;
        }

        if (!gameObject.GetComponent<Rigidbody2D>())
        {
            var rb = gameObject.AddComponent<Rigidbody2D>();

        }
    }
}