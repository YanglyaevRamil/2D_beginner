using UnityEngine;

public interface IPlayerState 
{
    void Walk(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator);
    void Idle(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator);
    void Jump(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator);
    void Climb(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator);
    void Crouch(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator);
    void Fall(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator);
}

