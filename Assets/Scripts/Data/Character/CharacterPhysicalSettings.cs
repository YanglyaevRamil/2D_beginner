using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterPhysicalSettings", menuName = "Configs/CharacterPhysicalSettings")]
public class CharacterPhysicalSettings : ScriptableObject
{
    [SerializeField]
    private float collisionThresh;

    public float CollisionThresh { get { return collisionThresh; } }
}
