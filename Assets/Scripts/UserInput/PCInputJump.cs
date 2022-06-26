using System;
using UnityEngine;

public sealed class PCInputJump : IUserInputProxy
{
    public event Action<float> AxisOnChange = delegate (float f) { };

    public void GetAxis()
    {
        AxisOnChange.Invoke(Input.GetAxis(AxisManager.JUMP));
        //var input = Input.GetButtonDown(AxisManager.JUMP);
        //AxisOnChange.Invoke(input ? 1:0) ;
    }
}
