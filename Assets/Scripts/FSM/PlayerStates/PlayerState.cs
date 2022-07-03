
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

    public virtual void Enter() 
    {

    }

    public virtual void Exit() 
    {
        _player.SpriteAnimator.StopAnimation(_player.PlayerView.SpriteRenderer);
    }

    public virtual void Execute(float deltaTime) 
    {
        if (_player.IsInputHor)
        {
            if (_player.IsInputHorPositiveX)
                _player.PlayerView.SpriteRenderer.flipX = false;
            else
                _player.PlayerView.SpriteRenderer.flipX = true;
        }
    }

    public virtual void FixedExecute() 
    {

    }

    public virtual void Cleanup() 
    {
    
    }
}