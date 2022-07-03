using System;
using UnityEngine;

public sealed class PCInputJump : IUserInputProxy
{
    public event Action<float> AxisOnChange = delegate (float f) { };

    public void GetAxis()
    {
        AxisOnChange.Invoke(Input.GetButtonDown(AxisManager.JUMP) ? 1:0) ;
    }
}
