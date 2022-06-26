
using UnityEngine;

public class JumpUpPlayerState : JumpPlayerState
{
    public JumpUpPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void Enter()
    {
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.JumpUp, true);
        //_player.PlayerView.Animator.SetBool(PlayerStateManager.JumpUp, true);
    }

    public override void Exit()
    {
        _player.SpriteAnimator.StopAnimation(_player.PlayerView.SpriteRenderer);
        //_player.PlayerView.Animator.SetBool(PlayerStateManager.JumpUp, false);
    }

    #region Root
    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);

        if (_player.PlayerView.Rigidbody2D.velocity.y < 0)
        {
            _stateMachine.ChangeState(_player.JumpDownPlayerState);
        }
    }

    public override void FixedExecute()
    {
        base.FixedExecute();
    }

    public override void Cleanup()
    {

    }
    #endregion
}