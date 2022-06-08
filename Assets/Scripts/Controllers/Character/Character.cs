using UnityEngine;

public class Character : ICleanup, IExecute
{
    private UserInput _userInput;
    private PlayerData _playerData;
    private SpriteAnimator _spriteAnimator;
    private SpriteRenderer _spriteRenderer;

    private IMoving _moving;
    private ILifeCycle _lifeCycle;
    public Character(UserInput userInput, PlayerData playerData, GameObject go)
    {
        _userInput = userInput;
        _playerData = playerData;

        _spriteRenderer = go?.GetComponent<SpriteRenderer>();
        _spriteAnimator = new SpriteAnimator(playerData.SpriteAnimationsConfig);
        
        _moving = new ObjectMoving(go?.GetComponent<Rigidbody2D>(), _playerData.Speed);
        _lifeCycle = new ObjectLifeCycle(_playerData.Health);

        _userInput.OninputFire += Fire;
        _userInput.OnInputHorizontal += MovingY;
        _userInput.OninputVertical += MovingX;
    }

    private void MovingY(float dir)
    {
        _moving.Moving(new Vector3(0f, dir, 0f));
    }

    private void AnimationMovingY(float dir)
    {
        if (dir > 0)
            _spriteAnimator.StartAnimation(_spriteRenderer, Track.Jump, true, _playerData.SpriteAnimationsConfig.SpeedAnimation);
        else
            _spriteAnimator.StopAnimation(_spriteRenderer);
    }
    
    private void MovingX(float dir)
    {
        _moving.Moving(new Vector3(dir, 0f, 0f));

        if (dir > 0)
            _spriteAnimator.StartAnimation(_spriteRenderer, Track.Walk, true, _playerData.SpriteAnimationsConfig.SpeedAnimation);
        else
            _spriteAnimator.StopAnimation(_spriteRenderer);
    }

    private void Fire(float obj)
    {
        Debug.Log(")= PEW =(");
    }

    public void Cleanup()
    {
        _userInput.OninputFire -= Fire;
        _userInput.OnInputHorizontal -= MovingY;
        _userInput.OninputVertical -= MovingX;
        _spriteAnimator.Cleanup();
    }

    public void DamageTake(int damageTaken)
    {
        _lifeCycle.DamageTake(damageTaken);

        if (_lifeCycle.DeathCheck(out var h))
        {
            Debug.Log(")= DEAD =(");
        }
    }

    public void Execute(float deltaTime)
    {
        _spriteAnimator.Execute(deltaTime);
    }
}
