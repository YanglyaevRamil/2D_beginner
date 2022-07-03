using System;
using UnityEngine;

public class UserInput : IExecute
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

    public event Action<float> OninputJump
    {
        add { _inputJump.AxisOnChange += value; }
        remove { _inputJump.AxisOnChange -= value; }
    }

    public event Action<float> OninputCrouch
    {
        add { _inputCrouch.AxisOnChange += value; }
        remove { _inputCrouch.AxisOnChange -= value; }
    }

    private IUserInputProxy _inputHorizontal;
    private IUserInputProxy _inputVertical;
    private IUserInputProxy _inputFire;
    private IUserInputProxy _inputJump;
    private IUserInputProxy _inputCrouch;

    public UserInput()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            return;
        }
        _inputHorizontal = new PCInputHorizontal();
        _inputVertical = new PCInputVertical();
        _inputFire = new PCInputFire();
        _inputJump = new PCInputJump();
        _inputCrouch = new PCInputCrouch();
    }

    public void FixedExecute()
    {

    }

    public void Execute(float deltaTime)
    {
        _inputJump.GetAxis();
        _inputHorizontal.GetAxis();
        _inputVertical.GetAxis();
        _inputFire.GetAxis();
        _inputCrouch.GetAxis();
    }
}
