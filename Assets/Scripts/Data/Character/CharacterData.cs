using System.Collections.Generic;
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
    private float speed;
    
    [SerializeField]
    private SpriteAnimationsConfig spriteAnimationsConfig;
    
    public CharacterType ÑharacterType { get { return characterType; } }
    public CharacterClass CharacterClass { get { return characterClass; } }
    public string Description { get { return description; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public float Speed { get { return speed; } }
    public SpriteAnimationsConfig SpriteAnimationsConfig => spriteAnimationsConfig;
}
