using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    #region SerializeField
    [SerializeField]
    private Rigidbody2D _rigidbody2D;

    [SerializeField]
    private CircleCollider2D _collider2D;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    #endregion

    #region getComponent_GO
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
    public CircleCollider2D CircleCollider2D { get { return _collider2D; } }
    public SpriteRenderer SpriteRenderer { get { return _spriteRenderer; } }
    public Transform Transform { get { return transform; } }
    #endregion

    #region Trigger
    public event Action<Transform> OnInteractionZoneEnter;
    public event Action OnInteractionZoneExit;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if ((collision.gameObject?.GetComponent<ICling>()) != null)
        {
            OnInteractionZoneEnter?.Invoke(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject?.GetComponent<ICling>()) != null)
        {
            OnInteractionZoneExit?.Invoke();
        }
    }
    #endregion
}
