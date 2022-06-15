
using UnityEngine;

public class CrouchPlayerState : PlayerState
{
    public override void Crouch(PlayerAction playerAction, SpriteRenderer spriteRenderer, SpriteAnimator spriteAnimator)
    {
        Debug.Log("Crouch");
    }
}