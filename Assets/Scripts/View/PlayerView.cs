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

    [SerializeField]
    private Animator _animator;
    #endregion

    #region getComponent_GO
    public Rigidbody2D Rigidbody2D { get { return _rigidbody2D; } }
    public CircleCollider2D CircleCollider2D { get { return _collider2D; } }
    public SpriteRenderer SpriteRenderer { get { return _spriteRenderer; } }
    public Animator Animator { get { return _animator; } }
    public Transform Transform { get { return transform; } }
    #endregion

    #region Trigger
    public event Action<Collider2D> OnInteractionZoneEnter;
    public event Action<ICoinProvider> OnCoinZone;
    public event Action<IDamageProvider> OnDamageZone;
    public event Action OnInteractionZoneExit;
    private ICoinProvider CoinProvider;
    private IDamageProvider DamageProvider;
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if ((collision.gameObject?.GetComponent<ICling>()) != null)
        {
            OnInteractionZoneEnter?.Invoke(collision);
        }

        if ((CoinProvider = collision.gameObject?.GetComponent<ICoinProvider>()) != null)
        {
            OnCoinZone?.Invoke(CoinProvider);
        }

        if ((DamageProvider = collision.gameObject?.GetComponent<IDamageProvider>()) != null)
        {
            OnDamageZone?.Invoke(DamageProvider);
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
