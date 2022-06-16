
using UnityEngine;

public class IdlePlayerState : PlayerState
{
    public override void Idle(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop)
    {
        if (startOrStop)
            spriteAnimator.StartAnimation(spriteRenderer, Track.Idle, true);
        else
            spriteAnimator.StartAnimation(spriteRenderer, Track.Idle, true);
    }
}