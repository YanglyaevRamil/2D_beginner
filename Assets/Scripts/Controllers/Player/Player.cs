using System;
using UnityEngine;

public class Player : ICleanup, IExecute
{
    private UserInput _userInput;
    private CharacterData _playerData;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private IMoving _moving;
    private ILifeCycle _lifeCycle;
    private IJumping _jumping;
    private IClimb _climb;

    private ContactsPoller _contactsPoller;
    private Animator _animator;

    private bool permissionClimb = false;

    public Player(UserInput userInput, CharacterData playerData, GameObject go)
    {
        _userInput = userInput;
        _playerData = playerData;

        _spriteRenderer = go?.GetComponent<SpriteRenderer>();
        _animator = new Animator(_spriteRenderer, playerData.SpriteAnimationsConfig);

        _rigidbody2D = go?.GetComponent<Rigidbody2D>();
        _moving = new ObjectMoving(_rigidbody2D, _playerData.SpeedMax, _playerData.Acceleration, playerData.CharacterPhysicalSettings.SpeedThresh);
        _lifeCycle = new ObjectLifeCycle(_playerData.Health);
        _jumping = new ObjectJump(_rigidbody2D);
        _climb = new ObjectClimb(_rigidbody2D, _playerData.SpeedClimb, _playerData.CharacterPhysicalSettings.ClimbThresh);

        _contactsPoller = new ContactsPoller(go?.GetComponent<CircleCollider2D>(), playerData.CharacterPhysicalSettings.CollisionThresh);

        var pv = go?.GetComponent<PlayerView>();
        pv.OnClingEnter += SetPermissionClimbEnter;
        pv.OnClingExit += SetPermissionClimbExit;

        _userInput.OnInputHorizontal += MovingX;
        _userInput.OninputVertical += Climb;
        _userInput.OninputJump += Jumping;
    }

    private void SetPermissionClimbEnter(Transform transform)
    {
        permissionClimb = true;
    }
    private void SetPermissionClimbExit()
    {
        permissionClimb = false;
        _rigidbody2D.gravityScale = _playerData.CharacterPhysicalSettings.GravityScale;
    }

    private void Jumping(float dir)
    {
        if (Math.Abs(dir) > 0)
            if (_contactsPoller.IsGrounded || permissionClimb)
            {
                _jumping.Jumping(_playerData.JumpForce);
                //_animator.SetAmimation(Track.Jump, false);
            }
            else
            {
                _animator.SetAmimation(Track.Idle, true);
            }
    }

    private void Climb(float dir)
    {
        if(Math.Abs(dir) > 0)
            if (permissionClimb)
            {
                _rigidbody2D.gravityScale = 0;
                _climb.Climb(dir);
                _animator.SetAmimation(Track.Climb, true);
            }
        else
            {
                _animator.SetAmimation(Track.Idle, true);
            }
    }
    
    private void MovingX(float dir)
    {
        if(Math.Abs(dir) > 0)
        {
            _moving.Moving(new Vector3(dir, 0f, 0f));
            _animator.SetAmimation(Track.Walk, true);
            if (dir > 0)
                _spriteRenderer.flipX = false;
            else
                _spriteRenderer.flipX = true;
        }
        else
        {
            _animator.SetAmimation(Track.Idle, true);
        }
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
        _contactsPoller.Execute(deltaTime);
        _animator.Execute(deltaTime);
    }

    public void Cleanup()
    {
        _userInput.OnInputHorizontal -= Climb;
        _userInput.OninputVertical -= MovingX;

        _animator.Cleanup();
    }
}
