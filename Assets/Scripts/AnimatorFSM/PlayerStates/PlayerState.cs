
using UnityEngine;

public abstract class PlayerState : IExecute, IFixedExecute, ICleanup
{
    protected Player _player;
    protected StateMachine _stateMachine;

    protected PlayerState(Player player, StateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
    }

    public abstract void Enter();

    public abstract void Exit();

    public abstract void Execute(float deltaTime);

    public abstract void FixedExecute();

    public abstract void Cleanup();
}