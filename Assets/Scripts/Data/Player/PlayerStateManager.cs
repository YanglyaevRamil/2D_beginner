
using UnityEngine;

public static class PlayerStateManager
{
    public static int Moving { get { return Animator.StringToHash(moving); } }
    public static int Idle { get { return Animator.StringToHash(idle); } }
    public static int JumpUp { get { return Animator.StringToHash(jumpUp); } }
    public static int JumpDown { get { return Animator.StringToHash(jumpDown); } }

    private const string moving = "Moving";
    private const string idle = "Idle";
    private const string jumpUp = "JumpUp";
    private const string jumpDown = "JumpDown";
}
