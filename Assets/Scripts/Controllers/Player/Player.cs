using System;
using UnityEngine;

public class Player : ICleanup, IExecute
{
    private UserInput _userInput;
    private CharacterData _playerData;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private PlayerComponents _playerComponents;

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

        _playerComponents = go?.GetComponent<PlayerComponents>();

        _spriteRenderer = _playerComponents.SpriteRendering;
        _rigidbody2D = _playerComponents.Rigidbody2D;

        _moving = new ObjectMoving(_rigidbody2D, _playerData.SpeedMax, _playerData.Acceleration, _playerData.CharacterSettings.SpeedThresh);
        _lifeCycle = new ObjectLifeCycle(_playerData.Health);
        _jumping = new ObjectJump(_rigidbody2D);
        _climb = new ObjectClimb(_rigidbody2D, _playerData.SpeedClimb, _playerData.CharacterSettings.ClimbThresh);

        _contactsPoller = new ContactsPoller(_playerComponents.CircleCollider2D, _playerData.CharacterSettings.CollisionThresh);

        var pv = go?.GetComponent<PlayerView>();
        pv.OnClingEnter += SetPermissionClimbEnter;
        pv.OnClingExit += SetPermissionClimbExit;

        _userInput.OnInputHorizontal += MovingX;
        _userInput.OninputVertical += Climb;
        _userInput.OninputJump += Jumping;
    }

    #region Character_Physics
    private void Jumping(float dir)
    {
        if (Math.Abs(dir) > 0)
        {
            if ((_contactsPoller.IsGrounded || permissionClimb) && (Math.Abs(_rigidbody2D.velocity.y) <= _playerData.CharacterSettings.FlyThresh))
            {
                _jumping.Jumping(_playerData.JumpForce);
            }
        }

        CheckJumpingAndSetState();
    }

    private void Climb(float dir)
    {
        if(Math.Abs(dir) > 0)
        {
            if (permissionClimb)
            {
                _playerAction.Climb(_spriteRenderer, true);

                _rigidbody2D.gravityScale = 0;
                _climb.Climb(dir);
            }
        }
        else
        {
            if (permissionClimb)
            {
                _playerAction.Climb(_spriteRenderer, false);
            }
        }
    }
    
    private void MovingX(float dir)
    {
        if(Math.Abs(dir) > 0)
        {
            _playerAction.Walk(_spriteRenderer, true);

            _moving.Moving(new Vector3(dir, 0f, 0f));
            _spriteRenderer.flipX = dir < 0;

            CheckJumpingAndSetState();
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
    #endregion

    #region Encapsulated_Conditions
    private void CheckJumpingAndSetState()
    {
        if (!_contactsPoller.IsGrounded && (Math.Abs(_rigidbody2D.velocity.magnitude) > 0))
        {
            if (_rigidbody2D.velocity.y > 0)
            {
                _playerAction.Jump(_spriteRenderer, true);
            }
            else
            {
                _playerAction.Fall(_spriteRenderer, true);
            }
        }
    }
    #endregion

    #region Communication_View
    private void SetPermissionClimbEnter(Transform transform)
    {
        permissionClimb = true;
    }

    private void SetPermissionClimbExit()
    {
        permissionClimb = false;
        _rigidbody2D.gravityScale = _playerData.CharacterSettings.GravityScale;
    }
    #endregion

    #region Root_Functions
    public void Execute(float deltaTime)
    {
        if (Math.Abs(_rigidbody2D.velocity.magnitude) == 0 && (_contactsPoller.IsGrounded))
        {
            _playerAction.Idle(_spriteRenderer, true);
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
    #endregion
}
