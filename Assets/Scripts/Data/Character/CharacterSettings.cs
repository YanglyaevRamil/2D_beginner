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

    [SerializeField]
    private int sortingOrder;

    [SerializeField]
    private RigidbodyType2D rigidbodyType2D;

    [SerializeField]
    private bool sumulated;

    [SerializeField]
    private bool useAutoMass;

    [SerializeField]
    private float mass;

    [SerializeField]
    private float linearDrag;

    [SerializeField]
    private float angularDrag;

    [SerializeField]
    private CollisionDetectionMode2D collisionDetectionMode2D;

    [SerializeField]
    private RigidbodySleepMode2D rigidbodySleepMode2D;

    [SerializeField]
    private RigidbodyInterpolation2D rigidbodyInterpolation2D;

    [SerializeField]
    private RigidbodyConstraints2D rigidbodyConstraints2D;

    [SerializeField]
    private bool isTrigger; 

    [SerializeField]
    private bool usedByEffector;

    [SerializeField]
    private Vector2 offset;

    [SerializeField]
    private float radius;

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
    public int SortingOrder { get { return sortingOrder; } }
    public RigidbodyType2D RigidbodyType2D { get { return rigidbodyType2D; } }
    public bool Sumulated { get { return sumulated; } }
    public bool UseAutoMass { get { return useAutoMass; } }
    public float Mass { get { return mass; } }
    public float LinearDrag { get { return linearDrag; } }
    public float AngularDrag { get { return angularDrag; } }
    public CollisionDetectionMode2D CollisionDetectionMode2D { get { return collisionDetectionMode2D; } }
    public RigidbodySleepMode2D RigidbodySleepMode2D { get { return rigidbodySleepMode2D; } }
    public RigidbodyInterpolation2D RigidbodyInterpolation2D { get { return rigidbodyInterpolation2D; } }
    public RigidbodyConstraints2D RigidbodyConstraints2D { get { return rigidbodyConstraints2D; } }
    public bool IsTrigger { get { return isTrigger; } }
    public bool UsedByEffector { get { return usedByEffector; } }
    public Vector2 Offset { get { return offset; } }
    public float Radius { get { return radius; } }
}
