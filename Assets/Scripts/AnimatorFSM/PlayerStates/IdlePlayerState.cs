
using UnityEngine;

public class IdlePlayerState : PlayerState
{
    public IdlePlayerState(Player player, StateMachine stateMachine) : base (player, stateMachine)
    {
        
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {

    }

    public override void Execute(float deltaTime)
    {
        //if (!_player.IsGraunded && _player.IsPositiveVelocityY)
        //    _stateMachine.ChangeState(_player.JumpPlayerState);
        //
        if (_player.IsGraunded && _player.IsInputHor)
            _stateMachine.ChangeState(_player.WalkPlayerState);
        
        //if (_player.IsInteractionStairs && !_player.IsGraunded)
        //    _stateMachine.ChangeState(_player.ClimbPlayerState);
    }

    public override void FixedExecute()
    {
        
    }
    
    public override void Cleanup()
    {
        
    }
}