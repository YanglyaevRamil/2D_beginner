
using UnityEngine;

public class JumpPlayerState : PlayerState
{
    private IJumping _jumping;
    private IMoving _moving;
    private int _numJump;
    private Vector2 _movDir;
    private Vector2 _jumpDir;
    public JumpPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
        _jumping = new ObjectJump(player.PlayerView.Rigidbody2D);
        _moving = new ObjectMoving(player.PlayerView.Rigidbody2D, player.PlayerData.SpeedMax, player.PlayerData.CharacterSettings.SpeedThresh);
        _numJump = _player.PlayerData.JumpNumber;
    }

    public override void Enter()
    {
        _stateMachine.ChangeState(_player.JumpUpPlayerState);
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
                //else
                    //_player.PlayerView.Rigidbody2D.velocity = Vector2.zero;
            }
            else
            {
                if (!_player.IsHasLeftContacts)
                    _movDir = (-1) * _player.PlayerData.Acceleration;
                //else
                    //_player.PlayerView.Rigidbody2D.velocity = Vector2.zero;
            }
        }
        else
        {
            //_player.PlayerView.Rigidbody2D.velocity = new Vector2(0, 0);
            _movDir = Vector2.zero;
        }
    }

    private void DevJumpLogic()
    {
        if (_player.IsGraunded)
        {
            _numJump = _player.PlayerData.JumpNumber;
        }

        if ((_player.IsGraunded || _player.IsInteractionStairs) && _player.IsInputJump)
        {
            if (_numJump-- > 0)
            {
                _jumpDir = Vector2.up * _player.PlayerData.JumpForce;
            }
        }
        else
        {
            _jumpDir = Vector2.zero;
        }
    }

    private void ChangeState()
    {
        if (_player.IsFixedX && _player.IsGraunded && _player.IsFixedY)
        {
            _stateMachine.ChangeState(_player.IdlePlayerState);
        }

        if (_player.IsGraunded && _player.IsInputHor && _player.PlayerView.Rigidbody2D.velocity.y == 0)
            _stateMachine.ChangeState(_player.WalkPlayerState);


        if (_player.IsInteractionStairs && _player.IsInputVer)
            _stateMachine.ChangeState(_player.ClimbPlayerState);
    }
    #endregion

    #region Root_Functions
    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);

        DevJumpLogic();

        DevMovLogic();

        ChangeState();

    }

    public override void FixedExecute()
    {
        base.FixedExecute();

        _jumping.Jumping(_jumpDir);

        _moving.Moving(_movDir);
    }

    public override void Cleanup()
    {
    }
    #endregion
}