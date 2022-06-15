
using UnityEngine;

public class WalkPlayerState : PlayerState
{
    public override void Walk(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        spriteAnimator.StartAnimation(spriteRenderer, Track.Walk, true);
        Debug.Log("Walk");
    }
}