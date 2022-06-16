
using UnityEngine;

public class CrouchPlayerState : PlayerState
{
    public override void Crouch(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop)
    {
        if (startOrStop)
            spriteAnimator.StartAnimation(spriteRenderer, Track.Crouch, true);
        else
            spriteAnimator.StopAnimation(spriteRenderer);
    }
}