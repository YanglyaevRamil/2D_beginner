using System;
using UnityEngine;

public class Player : ICleanup, IExecute
{
    private UserInput _userInput;
    private CharacterData _playerData;
    private SpriteAnimator _spriteAnimator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private IMoving _moving;
    private ILifeCycle _lifeCycle;
    private IJumping _jumping;
    private IClimb _climb;

    private ContactsPoller _contactsPoller;

    private bool permissionClimb = false;
    public Player(UserInput userInput, CharacterData playerData, GameObject go)
    {
        _userInput = userInput;
        _playerData = playerData;

        _spriteRenderer = go?.GetComponent<SpriteRenderer>();
        _spriteAnimator = new SpriteAnimator(_playerData.SpriteAnimationsConfig);
        _rigidbody2D = go?.GetComponent<Rigidbody2D>();

        _moving = new ObjectMoving(_rigidbody2D, _playerData.SpeedMax, _playerData.Acceleration);
        _lifeCycle = new ObjectLifeCycle(_playerData.Health);
        _jumping = new ObjectJump(_rigidbody2D);
        _climb = new ObjectClimb(_rigidbody2D, _playerData.SpeedClimb, _playerData.CharacterPhysicalSettings.ClimbThresh);

        _contactsPoller = new ContactsPoller(go?.GetComponent<CircleCollider2D>(), playerData.CharacterPhysicalSettings.CollisionThresh);

        var pv = go?.GetComponent<PlayerView>();
        pv.OnClingEnter += SetPermissionClimbEnter;
        pv.OnClingExit += SetPermissionClimbExit;

        _userInput.OnInputHorizontal += MovingX;
        _userInput.OnInputHorizontal += AnimationMovingX;
        _userInput.OninputVertical += Climb;
        _userInput.OninputVertical += AnimationMovingY;
        _userInput.OninputJump += Jumping;
    }

    private void SetPermissionClimbEnter(Transform transform)
    {
        permissionClimb = true;
    }
    private void SetPermissionClimbExit()
    {
        permissionClimb = false;
        _rigidbody2D.gravityScale = 3;
    }

    private void Jumping(float dir)
    {
        if (dir > 0 & (_contactsPoller.IsGrounded | permissionClimb))
        {
            _jumping.Jumping(_playerData.JumpForce);
        }
    }

    private void Climb(float dir)
    {
        if ((Math.Abs(dir) > 0) & permissionClimb)
        {
          _rigidbody2D.gravityScale = 0;
          _climb.Climb(dir);
        }
    }

    private void AnimationMovingY(float dir)
    {

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
        _contactsPoller.Execute(deltaTime);
    }

    public void Cleanup()
    {
        _userInput.OninputFire -= Fire;

        _userInput.OnInputHorizontal -= Climb;
        _userInput.OninputVertical -= MovingX;

        _userInput.OninputVertical -= AnimationMovingX;

        _spriteAnimator.Cleanup();
    }
}
