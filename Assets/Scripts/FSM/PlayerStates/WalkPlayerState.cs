
using UnityEngine;

public class WalkPlayerState : PlayerState
{
    private IMoving _moving;
    private Vector2 _movDir;

    public WalkPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
        _moving = new ObjectMoving(player.PlayerView.Rigidbody2D, player.PlayerData.SpeedMax, player.PlayerData.CharacterSettings.SpeedThresh);
    }

    public override void Enter()
    {
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.Moving, true);
        //_player.PlayerView.Animator.SetBool(PlayerStateManager.Moving, true);
    }

    public override void Exit()
    {
        _player.SpriteAnimator.StopAnimation(_player.PlayerView.SpriteRenderer);
        //_player.PlayerView.Animator.SetBool(PlayerStateManager.Moving, false);
    }

    #region Logic
    private void DevMovLogic()
    {
        if (_player.IsInputHor)
        {
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
            _player.PlayerView.Rigidbody2D.velocity = Vector2.zero;
            _movDir = Vector2.zero;
        }
    }

    private void ChangeState()
    {
        if (_player.IsGraunded && !_player.IsInputHor)
        {
            _stateMachine.ChangeState(_player.IdlePlayerState);
        }

        if ((_player.IsGraunded && _player.IsInputJump) || (!_player.IsGraunded))
        {
            _stateMachine.ChangeState(_player.JumpPlayerState);
        }

        if (_player.IsInteractionStairs && _player.IsInputVer)
            _stateMachine.ChangeState(_player.ClimbPlayerState);
    }
    #endregion

    #region Root_Functions
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