
using System;
using UnityEngine;

public class CrouchPlayerState : PlayerState
{
    private IMoving _moving;
    private Vector2 _movDir;
    public CrouchPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
        _moving = new ObjectMoving(player.PlayerView.Rigidbody2D, player.PlayerData.SpeedMax, player.PlayerData.CharacterSettings.SpeedThresh);
    }

    public override void Enter()
    {
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.Crouch, true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    #region Logic
    private void DevMovLogic()
    {
        if (_player.IsInputHor)
        {
            _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.Crouch, true);

            if (_player.IsInputHorPositiveX)
            {
                if (!_player.IsHasRightContacts)
                    _movDir = _player.PlayerData.Acceleration;
                else
                    _player.PlayerView.Rigidbody2D.velocity = Vector2.zero;
            }
            else
            {
                if (!_player.IsHasLeftContacts)
                    _movDir = (-1) * _player.PlayerData.Acceleration;
                else
                    _player.PlayerView.Rigidbody2D.velocity = Vector2.zero;
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
        if ((_player.IsGraunded && _player.IsInputJump) || (!_player.IsGraunded))
        {
            _stateMachine.ChangeState(_player.JumpPlayerState);
        }

        if ((_player.IsInteractionStairs != null) && _player.IsInputVer)
        {
            _stateMachine.ChangeState(_player.ClimbPlayerState);
        }

        if (_player.IsInputCrouch)
        {
            _stateMachine.ChangeState(_player.IdlePlayerState);
        }
    }

    #endregion

    #region Root
    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);

        DevMovLogic();

        ChangeState();
    }

    public override void FixedExecute()
    {
        base.FixedExecute();

        _moving.Moving(_movDir);
    }

    public override void Cleanup()
    {
    }
    #endregion
}