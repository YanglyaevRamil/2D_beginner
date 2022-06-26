
using UnityEngine;

public class CrouchPlayerState : PlayerState
{
    public CrouchPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
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
        base.Execute(deltaTime);
    }

    public override void FixedExecute()
    {
        base.FixedExecute();
    }

    public override void Cleanup()
    {
    }
}