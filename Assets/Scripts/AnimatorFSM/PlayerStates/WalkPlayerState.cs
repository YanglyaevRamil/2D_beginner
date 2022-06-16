
using UnityEngine;

public class WalkPlayerState : PlayerState
{
    public override void Walk(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop)
    {
        if (startOrStop)
            spriteAnimator.StartAnimation(spriteRenderer, Track.Walk, true);
        else
            spriteAnimator.StopAnimation(spriteRenderer);
    }
}