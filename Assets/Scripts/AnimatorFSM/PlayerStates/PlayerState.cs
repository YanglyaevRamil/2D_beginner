
using UnityEngine;

public class PlayerState : IPlayerState
{
    public virtual void Climb(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        playerAction.State = new ClimbPlayerState();
    }

    public virtual void Crouch(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    { 
        playerAction.State = new CrouchPlayerState();
    }

    public virtual void Fall(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        playerAction.State = new FallPlayerState();
    }

    public virtual void Idle(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        playerAction.State = new IdlePlayerState();
    }

    public virtual void Jump(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        playerAction.State = new JumpPlayerState();
    }

    public virtual void Walk(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        playerAction.State = new WalkPlayerState();
    }
}