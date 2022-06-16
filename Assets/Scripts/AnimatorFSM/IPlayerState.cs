using UnityEngine;

public interface IPlayerState 
{
    void Walk(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop);
    void Idle(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop);
    void Jump(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop);
    void Climb(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop);
    void Crouch(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop);
    void Fall(PlayerAction playerState, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator, bool startOrStop);
}

