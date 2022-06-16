using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterPhysicalSettings", menuName = "Configs/CharacterPhysicalSettings")]
public class CharacterSettings : ScriptableObject
{
    [SerializeField]
    private float collisionThresh;

    [SerializeField]
    private float climbThresh;

    [SerializeField]
    private float speedThresh;

    [SerializeField]
    private float flyThresh;

    [SerializeField]
    private float gravityScale;

    [SerializeField]
    private bool flipX;

    [SerializeField]
    private bool flipY;

    [SerializeField]
    private SpriteDrawMode spriteDrawMode;

    [SerializeField]
    private SpriteMaskInteraction spriteMaskInteraction;

    [SerializeField]
    private SpriteSortPoint spriteSortPoint;
    

    public float CollisionThresh { get { return collisionThresh; } }
    public float ClimbThresh { get { return climbThresh; } }
    public float SpeedThresh { get { return speedThresh; } }
    public float FlyThresh { get { return flyThresh; } }
    public float GravityScale { get { return gravityScale; } }
    public bool FlipX { get { return flipX; } }
    public bool FlipY { get { return flipY; } }
    public SpriteDrawMode SpriteDrawMode { get { return spriteDrawMode; } }
    public SpriteMaskInteraction SpriteMaskInteraction { get { return spriteMaskInteraction; } }
    public SpriteSortPoint SpriteSortPoint { get { return spriteSortPoint; } }
}
