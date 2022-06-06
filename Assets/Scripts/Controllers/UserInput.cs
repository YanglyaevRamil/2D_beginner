using System;
using UnityEngine;

public class UserInput : IFixedExecute
{
    public event Action<float> OnInputHorizontal
    {
        add { _inputHorizontal.AxisOnChange += value; }
        remove { _inputHorizontal.AxisOnChange -= value; }
    }

    public event Action<float> OninputVertical
    {
        add { _inputVertical.AxisOnChange += value; }
        remove { _inputVertical.AxisOnChange -= value; }
    }

    public event Action<float> OninputFire
    {
        add { _inputFire.AxisOnChange += value; }
        remove { _inputFire.AxisOnChange -= value; }
    }

    private IUserInputProxy _inputHorizontal;
    private IUserInputProxy _inputVertical;
    private IUserInputProxy _inputFire;

    public UserInput()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            return;
        }
        _inputHorizontal = new PCInputHorizontal();
        _inputVertical = new PCInputVertical();
        _inputFire = new PCInputFire();
    }

    public void FixedExecute()
    {
        _inputHorizontal.GetAxis();
        _inputVertical.GetAxis();
        _inputFire.GetAxis();
    }
}
