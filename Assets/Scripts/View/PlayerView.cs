using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public event Action<Transform> OnClingEnter;
    public event Action OnClingExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject?.GetComponent<ICling>()) != null)
        {
            OnClingEnter?.Invoke(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject?.GetComponent<ICling>()) != null)
        {
            OnClingExit?.Invoke();
        }
    }
}
