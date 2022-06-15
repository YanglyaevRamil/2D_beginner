
using UnityEngine;

public class IdlePlayerState : PlayerState
{
    public override void Idle(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        spriteAnimator.StartAnimation(spriteRenderer, Track.Idle, true);


        Debug.Log("Idle");
    }
}