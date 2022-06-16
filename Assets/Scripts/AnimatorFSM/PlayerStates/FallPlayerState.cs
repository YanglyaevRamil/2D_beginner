
using UnityEngine;

public class FallPlayerState : PlayerState
{
    public override void Fall(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop)
    {
        if (startOrStop)
            spriteAnimator.StartAnimation(spriteRenderer, Track.Fall, true);
        else
            spriteAnimator.StopAnimation(spriteRenderer);
    }
}