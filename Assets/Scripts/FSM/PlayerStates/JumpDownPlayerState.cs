
using UnityEngine;

public class JumpDownPlayerState : JumpPlayerState
{
    public JumpDownPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void Enter()
    {
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.JumpDown, true);
    }

    public override void Exit()
    {
        base.Exit();
        _player.SpriteAnimator.StopAnimation(_player.PlayerView.SpriteRenderer);
    }
    #region Logic
    protected override void ChangeState()
    {
        base.ChangeState();

        if (_player.IsGraunded && _player.IsInputHor)
        {
            _stateMachine.ChangeState(_player.WalkPlayerState);
        }

        if (_player.IsFixedX && _player.IsGraunded && _player.IsFixedY)
        {
            _stateMachine.ChangeState(_player.IdlePlayerState);
        }
    }
    #endregion

    #region Root
    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);

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