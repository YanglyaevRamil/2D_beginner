using System;
using UnityEngine;

public sealed class PCInputHorizontal : IUserInputProxy
{
    public event Action<float> AxisOnChange = delegate (float f) { };

    public void GetAxis()
    {
        //float input;
        //if(Math.Abs((input = Input.GetAxis(AxisManager.HORIZONTAL))) > 0)
        //    AxisOnChange.Invoke(input);
        AxisOnChange.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
    }
}
