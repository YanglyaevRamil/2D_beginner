
using UnityEngine;

public class IdlePlayerState : PlayerState
{
    public IdlePlayerState(Player player, StateMachine stateMachine) : base (player, stateMachine)
    {
        
    }

    public override void Enter()
    {
        //_player.PlayerView.Animator.SetBool(PlayerStateManager.Idle, true);
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.Idle, true);
    }

    public override void Exit()
    {
        _player.SpriteAnimator.StopAnimation(_player.PlayerView.SpriteRenderer);
        //_player.PlayerView.Animator.SetBool(PlayerStateManager.Idle, false);
    }

    #region Logic
    private void ChangeState()
    {
        if (_player.IsGraunded && _player.IsInputJump)
        {
            _stateMachine.ChangeState(_player.JumpPlayerState);
        }

        if (_player.IsGraunded && _player.IsInputHor)
        {
            _stateMachine.ChangeState(_player.WalkPlayerState);
        }

        if (_player.IsInteractionStairs && _player.IsGraunded && _player.IsInputVer)
        {
            _stateMachine.ChangeState(_player.ClimbPlayerState);
        }
    }
    #endregion

    #region Root
    public override void Execute(float deltaTime)
    {
        base.FixedExecute();

        ChangeState();
    }

    public override void FixedExecute()
    {
        
    }
    
    public override void Cleanup()
    {
        
    }
    #endregion
}