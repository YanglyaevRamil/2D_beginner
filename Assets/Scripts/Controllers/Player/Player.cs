using System;
using UnityEngine;

public class Player : ICleanup, IExecute
{
    private UserInput _userInput;
    private CharacterData _playerData;
    private SpriteAnimator _spriteAnimator;
    private SpriteRenderer _spriteRenderer;

    private IMoving _moving;
    private ILifeCycle _lifeCycle;
    private IJumping _jumping;

    private ContactsPoller _contactsPoller;

    private bool permissionClimb = false;
    public Player(UserInput userInput, CharacterData playerData, GameObject go)
    {
        _userInput = userInput;
        _playerData = playerData;

        _spriteRenderer = go?.GetComponent<SpriteRenderer>();
        _spriteAnimator = new SpriteAnimator(playerData.SpriteAnimationsConfig);

        var rb = go?.GetComponent<Rigidbody2D>();
        _moving = new ObjectMoving(rb, _playerData.SpeedMax, _playerData.Acceleration);
        _lifeCycle = new ObjectLifeCycle(_playerData.Health);
        _jumping = new ObjectJump(rb);

        _contactsPoller = new ContactsPoller(go?.GetComponent<CircleCollider2D>(), playerData.CharacterPhysicalSettings.CollisionThresh);


        _userInput.OnInputHorizontal += MovingX;
        _userInput.OnInputHorizontal += AnimationMovingX;
        _userInput.OninputVertical += MovingY;
        _userInput.OninputVertical += AnimationMovingY;
        _userInput.OninputJump += Jumping;

        var pv = go?.GetComponent<PlayerView>();
        pv.OnClingEnter += SetPermissionClimbEnter;
        pv.OnClingExit += SetPermissionClimbExit;
    }



    private void SetPermissionClimbEnter(Transform transform)
    {
        permissionClimb = true;
    }
    private void SetPermissionClimbExit()
    {
        permissionClimb = false;
    }

    private void Jumping(float dir)
    {
        if (dir > 0 & _contactsPoller.IsGrounded)
        {
            _jumping.Jumping(_playerData.JumpForce);
        }
    }

    private void MovingY(float dir)
    {
        if (dir > 0 & permissionClimb)
        {
            _moving.Moving(new Vector3(0, dir, 0f));
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

        _userInput.OnInputHorizontal -= MovingY;
        _userInput.OninputVertical -= MovingX;

        _userInput.OninputVertical -= AnimationMovingX;

        _spriteAnimator.Cleanup();
    }
}
