
using UnityEngine;

public class FallPlayerState : PlayerState
{
    public override void Fall(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        Debug.Log("Fall");
    }
}