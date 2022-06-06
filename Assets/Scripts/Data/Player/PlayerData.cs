using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "PlayerData", order = 51)]
public class PlayerData : ScriptableObject
{
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

    public string Description { get { return description; } }
    public int Health { get { return health; } }
    public int Damage { get { return damage; } }
    public float Speed { get { return speed; } }
    public List<SpritesSequence> SpritesSequence => _spritesSequence;
}
