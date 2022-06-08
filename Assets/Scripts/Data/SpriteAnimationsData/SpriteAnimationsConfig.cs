using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/SpriteAnimationsConfig")]
public class SpriteAnimationsConfig : ScriptableObject
{
    [SerializeField]
    private List<SpritesSequence> sequences;

    [SerializeField]
    private float speedAnimation;

    public List<SpritesSequence> Sequences => sequences;

    public float SpeedAnimation => speedAnimation;
}
