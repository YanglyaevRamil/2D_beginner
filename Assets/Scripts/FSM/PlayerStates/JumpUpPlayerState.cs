
using UnityEngine;

public class JumpUpPlayerState : JumpPlayerState
{
    private IJumping _jumping;

    private Vector2 _jumpDir;
    private int _numJump;
    public JumpUpPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
        _jumping = new ObjectJump(player.PlayerView.Rigidbody2D);
        _numJump = _player.PlayerData.JumpNumber;
    }

    public override void Enter()
    {
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.JumpUp, true);
        DevJumpLogic();
    }

    public override void Exit()
    {
        base.Exit();
    }

    #region Logic
    private void DevJumpLogic()
    {
        if (_player.IsGraunded || _player.IsInteractionStairs != null)
        {
            _numJump = _player.PlayerData.JumpNumber;
        }

        if ((_player.IsGraunded || _player.IsInteractionStairs != null) && _player.IsInputJump)
        {
            _jumpDir = Vector2.up * _player.PlayerData.JumpForce;
        }
        else
        {
            _jumpDir = Vector2.zero;
        }

        //_jumping.Jumping(_jumpDir);
    }

    protected override void ChangeState()
    {
        base.ChangeState();
    }
    #endregion

    #region Root
    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);

        if (_player.PlayerView.Rigidbody2D.velocity.y < -_player.PlayerData.CharacterSettings.FlyThresh)
        {
            _stateMachine.ChangeState(_player.JumpDownPlayerState);
        }
    }

    public override void FixedExecute()
    {
        base.FixedExecute();

        _jumping.Jumping(_jumpDir);
        _jumpDir = Vector2.zero;
    }

    public override void Cleanup()
    {

    }
    #endregion
}