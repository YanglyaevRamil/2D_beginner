using System;
using UnityEngine;

public class PlayerController : ICleanup, IExecute
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

    private bool permissionClimb = false;
    private bool isClimbs = false;

    public PlayerController(UserInput userInput, CharacterData playerData, PlayerView playerView)
    {
        _userInput = userInput;
        _playerData = playerData;

        _spriteRenderer = playerView.SpriteRenderer;
        _rigidbody2D = playerView.Rigidbody2D;

        _moving = new ObjectMoving(_rigidbody2D, _playerData.SpeedMax, _playerData.Acceleration, _playerData.CharacterSettings.SpeedThresh);
        _lifeCycle = new ObjectLifeCycle(_playerData.Health);
        _jumping = new ObjectJump(_rigidbody2D);
        _climb = new ObjectClimb(_rigidbody2D, _playerData.SpeedClimb, _playerData.CharacterSettings.ClimbThresh);

        _contactsPoller = new ContactsPoller(playerView.CircleCollider2D, _playerData.CharacterSettings.CollisionThresh);

        //playerView.OnClingEnter += SetPermissionClimbEnter;
        //playerView.OnClingExit += SetPermissionClimbExit;

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
        if (Math.Abs(dir) > 0)
        {
            if (permissionClimb)
            {
                isClimbs = true;
                //_playerAction.Climb(_spriteRenderer, true);

                _rigidbody2D.gravityScale = 0;
                _climb.Climb(dir);
            }
        }
        else
        {
            if (permissionClimb)
            {
                isClimbs = true;
                //_playerAction.Climb(_spriteRenderer, false);
            }
            isClimbs = false;
        }
    }

    private void MovingX(float dir)
    {
        if (Math.Abs(dir) > 0)
        {
            if ((!_contactsPoller.HasRightContacts && dir > 0) || (!_contactsPoller.HasLeftContacts && dir < 0))
            {
                _moving.Moving(new Vector2(dir, 0));
            }

            if (!isClimbs)
            {
                //_playerAction.Walk(_spriteRenderer, true);
                _spriteRenderer.flipX = dir < 0;
            }


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
        if (!_contactsPoller.IsGrounded && (Math.Abs(_rigidbody2D.velocity.magnitude) > 0) && !isClimbs)
        {
            if (_rigidbody2D.velocity.y > 0)
            {
                //_playerAction.Jump(_spriteRenderer, true);
            }
            else
            {
                //_playerAction.Fall(_spriteRenderer, true);
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
        if (Math.Abs(_rigidbody2D.velocity.magnitude) == 0 && (_contactsPoller.IsGrounded) && !isClimbs)
        {
            //_playerAction.Idle(_spriteRenderer, true);
        }

        //_contactsPoller.Execute(deltaTime);
        //_playerAction.Execute(deltaTime);
    }

    public void Cleanup()
    {
        _userInput.OnInputHorizontal -= Climb;
        _userInput.OninputVertical -= MovingX;

        //_playerAction.Cleanup();
    }
    #endregion
}