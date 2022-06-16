
using UnityEngine;

public class PlayerAction : IExecute, ICleanup
{
    public IPlayerState State { get { return _playerState; } set { _playerState = value; } }

    private IPlayerState _playerState;
    private SpriteAnimator _spriteAnimator;
    public PlayerAction(IPlayerState playerState, SpriteAnimationsConfig spriteAnimationsConfig)
    {
        _playerState = playerState;

        _spriteAnimator = new SpriteAnimator(spriteAnimationsConfig);
    }
    public void Climb(SpriteRenderer spriteRenderer, bool startOrStop)
    {
        _playerState.Climb(this, spriteRenderer, _spriteAnimator, startOrStop);
    }

    public void Crouch(SpriteRenderer spriteRenderer, bool startOrStop)
    {
        _playerState.Crouch(this, spriteRenderer, _spriteAnimator, startOrStop);
    }

    public void Idle(SpriteRenderer spriteRenderer, bool startOrStop)
    {
        _playerState.Idle(this, spriteRenderer, _spriteAnimator, startOrStop);
    }

    public void Jump(SpriteRenderer spriteRenderer, bool startOrStop)
    {
        _playerState.Jump(this, spriteRenderer, _spriteAnimator, startOrStop);
    }

    public void Walk(SpriteRenderer spriteRenderer, bool startOrStop)
    {
        _playerState.Walk(this, spriteRenderer, _spriteAnimator, startOrStop);
    }

    public void Fall(SpriteRenderer spriteRenderer, bool startOrStop)
    {
        _playerState.Fall(this, spriteRenderer, _spriteAnimator, startOrStop);
    }

    public void Execute(float deltaTime)
    {
        _spriteAnimator.Execute(deltaTime);
    }

    public void Cleanup()
    {
        _spriteAnimator.Cleanup();
    }
}