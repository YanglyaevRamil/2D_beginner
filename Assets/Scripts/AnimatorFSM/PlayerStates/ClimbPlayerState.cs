
using UnityEngine;

public class ClimbPlayerState : PlayerState
{
    public override void Climb(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        spriteAnimator.StartAnimation(spriteRenderer, Track.Climb, true);
        Debug.Log("Climb");
    }
}