using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterData", menuName = "CharacterData", order = 51)]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    private CharacterType characterType;

    [SerializeField]
    private string description;

    [SerializeField, Range(0, 100)]
    private int health;

    [SerializeField]
    private int damage;

    [SerializeField]
    private float speed;

    [SerializeField]
    private List<SpritesSequence> _spritesSequence;

    public CharacterType ÑharacterType { get { return characterType; } }
    public string Description { get { return description; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public float Speed { get { return speed; } }
    public List<SpritesSequence> SpritesSequence => _spritesSequence;
}
