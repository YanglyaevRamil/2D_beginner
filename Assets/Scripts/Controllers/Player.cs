using System;
using UnityEngine;

public class Player : ICleanup
{
    private UserInput _userInput; 
    private PlayerData _playerData;

    private IMoving moving;
    private ILifeCycle lifeCycle;
    public Player(UserInput userInput, PlayerData playerData, GameObject go)
    {
        _userInput = userInput;
        _playerData = playerData;
        
        moving = new ObjectMoving(go?.GetComponent<Rigidbody2D>(), _playerData.Speed);
        lifeCycle = new ObjectLifeCycle(_playerData.Health);

        _userInput.OninputFire += Fire;
        _userInput.OnInputHorizontal += MovingY;
        _userInput.OninputVertical += MovingX;
    }

    private void MovingY(float dir)
    {
        moving.Moving(new Vector3(0f, dir, 0f));
    }
    
    private void MovingX(float dir)
    {
        moving.Moving(new Vector3(dir, 0f, 0f));
    }

    private void Fire(float obj)
    {
        throw new NotImplementedException();
    }

    public void Cleanup()
    {
        _userInput.OninputFire -= Fire;
        _userInput.OnInputHorizontal -= MovingY;
        _userInput.OninputVertical -= MovingX;
    }

    public void DamageTake(int damageTaken)
    {
        lifeCycle.DamageTake(damageTaken);

        if (lifeCycle.DeathCheck(out var h))
        {
            _playerData.Health = h;
            Debug.Log(")= DEAD =(");
        }
    }
}
