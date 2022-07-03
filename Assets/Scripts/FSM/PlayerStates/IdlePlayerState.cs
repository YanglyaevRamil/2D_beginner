
using UnityEngine;

public class IdlePlayerState : PlayerState
{
    public IdlePlayerState(Player player, StateMachine stateMachine) : base (player, stateMachine)
    {
        
    }

    public override void Enter()
    {
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.Idle, true);
    }

    public override void Exit()
    {
        base.Exit();
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

        if (_player.IsInteractionStairs != null && _player.IsGraunded && _player.IsInputVer)
        {
            _stateMachine.ChangeState(_player.ClimbPlayerState);
        }

        if (_player.IsGraunded && _player.IsInputCrouch)
        {
            _stateMachine.ChangeState(_player.CrouchPlayerState);
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