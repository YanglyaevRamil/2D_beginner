using System;
using UnityEngine;

public sealed class PCInputJump : IUserInputProxy
{
    public event Action<float> AxisOnChange = delegate (float f) { };

    public void GetAxis()
    {
        //bool x; 
        //AxisOnChange.Invoke(Input.GetAxis(AxisManager.JUMP));
        //AxisOnChange.Invoke(Input.GetButtonDown(AxisManager.JUMP) ? 1f : 0f);
        //if (x = Input.GetButtonDown(AxisManager.JUMP))
        AxisOnChange.Invoke(Input.GetAxis(AxisManager.JUMP));
    }
}
