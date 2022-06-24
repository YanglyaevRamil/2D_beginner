using System;
using UnityEngine;

public class Player : IExecute, IFixedExecute
{


    #region Private_Fields
    private UserInput _userInput;
    private CharacterData _playerData;
    private PlayerView _playerView;

    private Rigidbody2D _rigidbody2D;
    private ContactsPoller _contactsPoller;

    private StateMachine _SM;
    #endregion

    #region Public_Fields
    public CharacterData PlayerData { get { return _playerData; } }
    public PlayerView PlayerView { get { return _playerView; } }

    public ClimbPlayerState ClimbPlayerState { get; private set; }
    public CrouchPlayerState CrouchPlayerState { get; private set; }
    public FallPlayerState FallPlayerState { get; private set; }
    public IdlePlayerState IdlePlayerState { get; private set; }
    public JumpPlayerState JumpPlayerState { get; private set; }
    public WalkPlayerState WalkPlayerState { get; private set; }

    public bool IsInputHor { get; private set; }
    public bool IsInputVer { get; private set; }
    public bool IsInputJump { get; private set; }
    public bool IsGraunded { get { return _contactsPoller.IsGrounded; } }
    public bool IsInteractionStairs { get; private set; }
    public bool IsPositiveVelocityX { get { return _rigidbody2D.velocity.x > 0; } }
    public bool IsPositiveVelocityY { get { return _rigidbody2D.velocity.y > 0; } }
    public bool IsHasRightContacts { get { return _contactsPoller.HasRightContacts; } }
    public bool IsHasLeftContacts { get { return _contactsPoller.HasLeftContacts; } }
    public bool IsFly { get { return _contactsPoller.IsFly; } }
    public bool IsFixed { get { return Math.Abs(_rigidbody2D.velocity.y) == 0; } }
    #endregion

    public Player(UserInput userInput, CharacterData playerData, PlayerView playerView)
    {
        _userInput = userInput;
        _playerData = playerData;
        _playerView = playerView;

        _rigidbody2D = _playerView.Rigidbody2D;
        _contactsPoller = new ContactsPoller(_playerView.CircleCollider2D, _playerData.CharacterSettings.CollisionThresh);

        _playerView.OnInteractionZoneEnter += SetIsInteractionEnter;
        _playerView.OnInteractionZoneExit += SetIsInteractionExit;

        _userInput.OnInputHorizontal += SetIsInputHorizontal;
        _userInput.OninputVertical += SetIsInputVertical;
        _userInput.OninputJump += SetIsInputJump;

        _SM = new StateMachine();
        ClimbPlayerState = new ClimbPlayerState(this, _SM);
        CrouchPlayerState = new CrouchPlayerState(this, _SM);
        FallPlayerState = new FallPlayerState(this, _SM);
        IdlePlayerState = new IdlePlayerState(this, _SM);
        JumpPlayerState = new JumpPlayerState(this, _SM);
        WalkPlayerState = new WalkPlayerState(this, _SM);
        _SM.Initialize(IdlePlayerState);
    }

    #region Set_Actions_Player
    private void SetIsInputHorizontal(float dir)
    {
        IsInputHor = false;

        if(Math.Abs(dir) > 0)
        {
            IsInputHor = true;
        }
    }

    private void SetIsInputVertical(float dir)
    {
        IsInputVer = false;

        if (Math.Abs(dir) > 0)
        {
            IsInputVer = true;
        }
    }

    private void SetIsInputJump(float dir)
    {
        IsInputJump = false;

        if (Math.Abs(dir) > 0)
        {
            IsInputJump = true;
        }
    }

    private void SetIsInteractionEnter(Transform transform)
    {
        IsInteractionStairs = true;
    }

    private void SetIsInteractionExit()
    {
        IsInteractionStairs = false;
    }
    #endregion

    #region Root_Functions
    public void Cleanup()
    {
        _playerView.OnInteractionZoneEnter -= SetIsInteractionEnter;
        _playerView.OnInteractionZoneExit -= SetIsInteractionExit;

        _userInput.OnInputHorizontal -= SetIsInputHorizontal;
        _userInput.OninputVertical -= SetIsInputVertical;
        _userInput.OninputJump -= SetIsInputJump;

        _SM.CurrentState.Cleanup();
    }

    public void Execute(float deltaTime)
    {
        _SM.CurrentState.Execute(deltaTime);
        Debug.Log(_contactsPoller.IsGrounded);
    }

    public void FixedExecute()
    {
        _SM.CurrentState.FixedExecute();
    }
    #endregion
}
