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
    private Vector2 speedClimb;

    [SerializeField]
    private Vector2 speedMax;

    [SerializeField]
    private Vector2 acceleration;

    [SerializeField]
    private Vector2 jumpForce;

    [SerializeField]
    private int jumpNumber;

    [SerializeField]
    private SpriteAnimationsConfig spriteAnimationsConfig;

    [SerializeField]
    private CharacterSettings characterSettings;

    public CharacterType CharacterType { get { return characterType; } }
    public CharacterClass CharacterClass { get { return characterClass; } }
    public string Description { get { return description; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public Vector2 SpeedClimb { get { return speedClimb; } }
    public Vector2 SpeedMax { get { return speedMax; } }
    public Vector2 Acceleration { get { return acceleration; } }
    public Vector2 JumpForce { get { return jumpForce; } }
    public int JumpNumber { get { return jumpNumber; } }
    public SpriteAnimationsConfig SpriteAnimationsConfig => spriteAnimationsConfig;
    public CharacterSettings CharacterSettings { get { return characterSettings; } }
}
