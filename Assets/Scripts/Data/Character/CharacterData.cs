using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterData", menuName = "Configs/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    private CharacterType characterType;

    [SerializeField]
    private CharacterClass characterClass;

    [SerializeField]
    private string description;

    [SerializeField, Range(0, 100)]
    private int health;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float speedMax;

    [SerializeField]
    private float acceleration;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private SpriteAnimationsConfig spriteAnimationsConfig;

    [SerializeField]
    private CharacterPhysicalSettings characterPhysicalSettings;

    public CharacterType ÑharacterType { get { return characterType; } }
    public CharacterClass CharacterClass { get { return characterClass; } }
    public string Description { get { return description; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public float SpeedMax { get { return speedMax; } }
    public float Acceleration { get { return acceleration; } }
    public float JumpForce { get { return jumpForce; } }
    public SpriteAnimationsConfig SpriteAnimationsConfig => spriteAnimationsConfig;
    public CharacterPhysicalSettings CharacterPhysicalSettings { get { return characterPhysicalSettings; } }
}
