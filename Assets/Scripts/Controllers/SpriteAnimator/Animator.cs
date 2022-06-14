using System;
using System.Collections.Generic;
using UnityEngine;

public class Animator : IExecute, ICleanup
{
    private SpriteAnimator _spriteAnimator;
    private Dictionary<Track, bool> states;
    private SpriteAnimationsConfig _spriteAnimationsConfig;
    private SpriteRenderer _spriteRenderer;
    public Animator(SpriteRenderer spriteRenderer, SpriteAnimationsConfig spriteAnimationsConfig)
    {
        _spriteRenderer = spriteRenderer;
        states = new Dictionary<Track, bool>();
        for (int i = 0; i < Enum.GetNames(typeof(Track)).Length; i++)
        {
            states.Add((Track)i, false);
        }
        SetFSM(Track.Idle);

        _spriteAnimator = new SpriteAnimator(spriteAnimationsConfig);
        _spriteAnimationsConfig = spriteAnimationsConfig;

    }
    private void PlayAnimation()
    {
        for (int i = 0; i < states.Count; i++)
        {
            if (states[(Track)i])
            {
                _spriteAnimator.StartAnimation(_spriteRenderer, (Track)i, true, _spriteAnimationsConfig.SpeedAnimation);
                break;
            }
        }
    }

    public void SetFSM(Track track)
    {
        for (int i = 0; i < states.Count; i++)
        {
            if ((Track)i == track)
            {
                states[(Track)i] = true;
            }
            else
            {
                states[(Track)i] = false;
            }
        }
    }

    public void Cleanup()
    {
        _spriteAnimator.Cleanup();
    }

    public void Execute(float deltaTime)
    {
        PlayAnimation();
        _spriteAnimator.Execute(deltaTime);
    }
}