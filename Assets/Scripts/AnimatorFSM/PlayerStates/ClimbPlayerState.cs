
using UnityEngine;

public class ClimbPlayerState : PlayerState
{
    public override void Climb(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop)
    {
        if (startOrStop)
            spriteAnimator.StartAnimation(spriteRenderer, Track.Climb, true);
        else
            spriteAnimator.StopAnimation(spriteRenderer);
    }
}