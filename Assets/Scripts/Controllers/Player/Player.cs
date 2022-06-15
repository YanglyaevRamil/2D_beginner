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
    private PlayerAction _playerAction;

    private bool permissionClimb = false;

    public Player(UserInput userInput, CharacterData playerData, GameObject go)
    {
        _playerAction = new PlayerAction(new IdlePlayerState(), playerData.SpriteAnimationsConfig);

        _userInput = userInput;
        _playerData = playerData;

        _spriteRenderer = go?.GetComponent<SpriteRenderer>();
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
        {
            if ((_contactsPoller.IsGrounded || permissionClimb) && (Math.Abs(_rigidbody2D.velocity.y) <= _playerData.CharacterPhysicalSettings.FlyThresh))
            {
                _jumping.Jumping(_playerData.JumpForce);
            }
        }

        if (!_contactsPoller.IsGrounded && (Math.Abs(_rigidbody2D.velocity.y) > 0))
        {
            if (_rigidbody2D.velocity.y > 0)
            {
                _playerAction.Jump(_spriteRenderer);
            }
            else
            {
                _playerAction.Fall(_spriteRenderer);
            }
        }
    }

    private void Climb(float dir)
    {
        if(Math.Abs(dir) > 0)
        {
            if (permissionClimb)
            {
                _playerAction.Climb(_spriteRenderer);

                _rigidbody2D.gravityScale = 0;
                _climb.Climb(dir);
            }
        }
    }
    
    private void MovingX(float dir)
    {
        if(Math.Abs(dir) > 0)
        {
            _playerAction.Walk(_spriteRenderer);

            _moving.Moving(new Vector3(dir, 0f, 0f));
            _spriteRenderer.flipX = dir < 0;
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
        if (Math.Abs(_rigidbody2D.velocity.magnitude) == 0 )
        {
            _playerAction.Idle(_spriteRenderer);
        }

        _contactsPoller.Execute(deltaTime);
        _playerAction.Execute(deltaTime);
    }

    public void Cleanup()
    {
        _userInput.OnInputHorizontal -= Climb;
        _userInput.OninputVertical -= MovingX;

        _playerAction.Cleanup();
    }
}
