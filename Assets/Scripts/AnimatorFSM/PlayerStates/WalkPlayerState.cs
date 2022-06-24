
using UnityEngine;

public class WalkPlayerState : PlayerState
{
    private IMoving _moving;

    public WalkPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
        _moving = new ObjectMoving(player.PlayerView.Rigidbody2D, player.PlayerData.SpeedMax, player.PlayerData.Acceleration, player.PlayerData.CharacterSettings.SpeedThresh);
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {

    }

    public override void Execute(float deltaTime)
    {
    }

    public override void FixedExecute()
    {
        if (_player.IsInputHor)
        {
            if (_player.IsPositiveVelocityX)
                _moving.Moving(new Vector2(1, 0));
            else
                _moving.Moving(new Vector2(-1, 0));
        }
            
    }

    public override void Cleanup()
    {
    }
}