
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
    public void Climb(SpriteRenderer spriteRenderer)
    {
        _playerState.Climb(this, spriteRenderer, _spriteAnimator);
    }

    public void Crouch(SpriteRenderer spriteRenderer)
    {
        _playerState.Crouch(this, spriteRenderer, _spriteAnimator);
    }

    public void Idle(SpriteRenderer spriteRenderer)
    {
        _playerState.Idle(this, spriteRenderer, _spriteAnimator);
    }

    public void Jump(SpriteRenderer spriteRenderer)
    {
        _playerState.Jump(this, spriteRenderer, _spriteAnimator);
    }

    public void Walk(SpriteRenderer spriteRenderer)
    {
        _playerState.Walk(this, spriteRenderer, _spriteAnimator);
    }

    public void Fall(SpriteRenderer spriteRenderer)
    {
        _playerState.Fall(this, spriteRenderer, _spriteAnimator);
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