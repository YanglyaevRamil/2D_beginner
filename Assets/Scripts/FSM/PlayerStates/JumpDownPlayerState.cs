
public class JumpDownPlayerState : JumpPlayerState
{
    public JumpDownPlayerState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override void Enter()
    {
        _player.SpriteAnimator.StartAnimation(_player.PlayerView.SpriteRenderer, Track.JumpDown, true);
        //_player.PlayerView.Animator.SetBool(PlayerStateManager.JumpDown, true);
    }

    public override void Exit()
    {
        _player.SpriteAnimator.StopAnimation(_player.PlayerView.SpriteRenderer);
        //_player.PlayerView.Animator.SetBool(PlayerStateManager.JumpDown, false);
    }

    #region Root
    public override void Execute(float deltaTime)
    {
        base.Execute(deltaTime);

    }

    public override void FixedExecute()
    {
        base.FixedExecute();

    }

    public override void Cleanup()
    {

    }
    #endregion
}