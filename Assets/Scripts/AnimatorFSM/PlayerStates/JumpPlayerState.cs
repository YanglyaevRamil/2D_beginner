
using UnityEngine;

public class JumpPlayerState : PlayerState
{
    public override void Jump(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop)
    {
        if (startOrStop)
            spriteAnimator.StartAnimation(spriteRenderer, Track.Jump, true);
        else
            spriteAnimator.StopAnimation(spriteRenderer);
    }
}