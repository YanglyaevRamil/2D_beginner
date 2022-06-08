using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : ICleanup, IExecute
{
    private SpriteAnimationsConfig _config;
    private Dictionary<SpriteRenderer, CustomAnimation> _activeAnimations = new Dictionary<SpriteRenderer, CustomAnimation>();

    public SpriteAnimator(SpriteAnimationsConfig config)
    {
        _config = config;
    }

    public void StartAnimation(SpriteRenderer spriteRenderer, Track track, bool loop, float speed)
    {
        if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
        {
            animation.Loop = loop;
            animation.Speed = speed;
            animation.Sleeps = false;

            if (animation.Track == track) 
                return;
            
            animation.Track = track;
            animation.Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites;
            animation.Counter = 0;
        }
        else
        {
            _activeAnimations.Add(spriteRenderer, new CustomAnimation
            {
                Track = track,
                Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites,
                Loop = loop,
                Speed = speed
            });
        }
    }

    public void StopAnimation(SpriteRenderer sprite)
    {
        if (_activeAnimations.ContainsKey(sprite))
            _activeAnimations.Remove(sprite);
    }

    public void Cleanup()
    {
        _activeAnimations.Clear();
    }

    public void Execute(float deltaTime)
    {
        if (_activeAnimations.Count != 0)
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Update(deltaTime);
                animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
            }
    }
}