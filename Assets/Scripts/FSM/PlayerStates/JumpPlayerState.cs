
using UnityEngine;

public class JumpPlayerState : PlayerState
{
    private IMoving _moving;
    private Vector2 _movDir;

    public JumpPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
        _moving = new ObjectMoving(player.PlayerView.Rigidbody2D, player.PlayerData.SpeedMax, player.PlayerData.CharacterSettings.SpeedThresh);
    }

    public override void Enter()
    {
        _stateMachine.ChangeState(_player.JumpUpPlayerState);
    }

    public override void Exit()
    {
        
    }

    #region Logic
    private void DevMovLogic()
    {
        if (_player.IsInputHor)
        {
            if (_player.IsInputHorPositiveX)
            {
                _movDir = _player.PlayerData.Acceleration;
            }
            else
            {
                _movDir = (-1) * _player.PlayerData.Acceleration;
            }
        }
        else
        {
            _movDir = Vector2.zero;
        }
    }

    protected virtual void ChangeState()
    {
        if (_player.IsInteractionStairs != null && _player.IsInputVer)
        {
            _stateMachine.ChangeState(_player.ClimbPlayerState);
        }
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