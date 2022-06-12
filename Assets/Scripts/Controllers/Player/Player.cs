using UnityEngine;

public class Player : ICleanup, IExecute
{
    private UserInput _userInput;
    private CharacterData _playerData;
    private SpriteAnimator _spriteAnimator;
    private SpriteRenderer _spriteRenderer;

    private IMoving _moving;
    private ILifeCycle _lifeCycle;

    private bool peaceFlag;
    public Player(UserInput userInput, CharacterData playerData, GameObject go)
    {
        _userInput = userInput;
        _playerData = playerData;

        _spriteRenderer = go?.GetComponent<SpriteRenderer>();
        _spriteAnimator = new SpriteAnimator(playerData.SpriteAnimationsConfig);
        

        _moving = new ObjectMoving(go?.GetComponent<Rigidbody2D>(), _playerData.Speed);
        _lifeCycle = new ObjectLifeCycle(_playerData.Health);

        //_userInput.OninputFire += Fire;
        //_userInput.OnInputHorizontal += MovingY;
        //_userInput.OnInputHorizontal += AnimationMovingY;
        _userInput.OnInputHorizontal += MovingX;
        _userInput.OnInputHorizontal += AnimationMovingX;
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
        if (dir > 0 || dir < 0)
        {
            _moving.Moving(new Vector3(dir, 0f, 0f));
        }
    }

    private void AnimationMovingX(float dir)
    {
        if (dir > 0)
        {
            if (_spriteRenderer.flipX) { _spriteRenderer.flipX = !_spriteRenderer.flipX; }
                
            _spriteAnimator.StartAnimation(_spriteRenderer, Track.Walk, true, _playerData.SpriteAnimationsConfig.SpeedAnimation);
        }
        else if (dir < 0)
        {
            if (!_spriteRenderer.flipX ) { _spriteRenderer.flipX = !_spriteRenderer.flipX; }

            _spriteAnimator.StartAnimation(_spriteRenderer, Track.Walk, true, _playerData.SpriteAnimationsConfig.SpeedAnimation);
        }
        else
        {
            _spriteAnimator.StartAnimation(_spriteRenderer, Track.Idle, true, _playerData.SpriteAnimationsConfig.SpeedAnimation);
        }
    }

    private void Fire(float obj)
    {
      
    }

    public void Cleanup()
    {
        _userInput.OninputFire -= Fire;
        _userInput.OnInputHorizontal -= MovingY;
        _userInput.OninputVertical -= MovingX;
        _userInput.OnInputHorizontal -= AnimationMovingY;
        _userInput.OninputVertical -= AnimationMovingX;
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
