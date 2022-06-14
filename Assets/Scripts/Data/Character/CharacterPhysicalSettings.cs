using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterPhysicalSettings", menuName = "Configs/CharacterPhysicalSettings")]
public class CharacterPhysicalSettings : ScriptableObject
{
    [SerializeField]
    private float collisionThresh;

    [SerializeField]
    private float climbThresh;

    [SerializeField]
    private float speedThresh;

    [SerializeField]
    private float gravityScale;
    
    public float CollisionThresh { get { return collisionThresh; } }
    public float ClimbThresh { get { return climbThresh; } }
    public float SpeedThresh { get { return speedThresh; } }
    public float GravityScale { get { return gravityScale; } }
}
