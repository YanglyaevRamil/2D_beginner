
using UnityEngine;

public class ClimbPlayerState : PlayerState
{
    private IMoving _moving;
    private Vector2 _movDir;

    public ClimbPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
        _moving = new ObjectMoving(player.PlayerView.Rigidbody2D, player.PlayerData.SpeedClimb, player.PlayerData.CharacterSettings.ClimbThresh);
    }

    public override void Enter()
    {
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.Climb, true);
        _player.PlayerView.Rigidbody2D.gravityScale = 0;
    }

    public override void Exit()
    {
        base.Exit();
        _player.PlayerView.Rigidbody2D.gravityScale = _player.PlayerData.CharacterSettings.GravityScale;
    }

    #region Logic
    private void DevClimbLogic()
    {
        if (_player.IsInputVer || _player.IsInputHor)
        {
            _movDir = Vector2.zero;

            if (_player.IsInputVer)
            {
                _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.Climb, true);

                if (_player.IsInputVerPositivY)
                {
                    _movDir.y = _player.PlayerData.SpeedClimb.y;
                }
                else
                {
                    _movDir.y = (-1) * _player.PlayerData.SpeedClimb.y;
                }
            }

            if (_player.IsInputHor)
            {
                if (_player.IsInputHorPositiveX)
                {
                    _movDir.x = _player.PlayerData.SpeedClimb.x;
                }
                else
                {
                    _movDir.x = (-1) * _player.PlayerData.SpeedClimb.x;
                }
            }
        }
        else
        {
            _player.SpriteAnimator.StopAnimation(_player.PlayerView.SpriteRenderer);

            _player.PlayerView.Rigidbody2D.velocity = Vector2.zero;
            _movDir = Vector2.zero;
        }
    }

    private void ChangeState()
    {
        if (_player.IsFixedX && _player.IsGraunded && _player.IsFixedY)
        {
            _stateMachine.ChangeState(_player.IdlePlayerState);
        }

        if (_player.IsInputJump || _player.IsInteractionStairs == null)
        {
            _stateMachine.ChangeState(_player.JumpPlayerState);
        }
    }
    #endregion

    #region Root
    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);
        
        DevClimbLogic();

        ChangeState();
    }

    public override void FixedExecute()
    {
        base.FixedExecute();

        _moving.MovePosition(_movDir);

    }

    public override void Cleanup()
    {
    }
    #endregion
}