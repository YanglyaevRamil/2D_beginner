
using UnityEngine;

public class JumpPlayerState : PlayerState
{
    public override void Jump(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        Debug.Log("Jump");
    }
}