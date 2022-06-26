using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterPhysicalSettings", menuName = "Configs/CharacterPhysicalSettings")]
public class CharacterSettings : ScriptableObject
{
    [SerializeField]
    private float collisionThresh;

    [SerializeField]
    private Vector2 climbThresh;

    [SerializeField]
    private Vector2 speedThresh;

    [SerializeField]
    private float flyThresh;

    [SerializeField]
    private float gravityScale;


    public float CollisionThresh { get { return collisionThresh; } }
    public Vector2 ClimbThresh { get { return climbThresh; } }
    public Vector2 SpeedThresh { get { return speedThresh; } }
    public float FlyThresh { get { return flyThresh; } }
    public float GravityScale { get { return gravityScale; } }
}
