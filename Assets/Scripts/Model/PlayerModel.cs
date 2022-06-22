
public class PlayerModel 
{
    public CharacterType CharacterType { get { return _characterType; } }
    public CharacterClass CharacterClass { get { return _characterClass; } set { _characterClass = value; } }
    public string Description { get { return _description; } }
    public int HealthMax { get { return _healthMax; } set { _healthMax = value; } }
    public int HealthNow { get { return _healthNow; } set { _healthNow = value; } }
    public int Damage { get { return _damage; } set { _damage = value; } }
    public float SpeedClimb { get { return _speedClimb; } set { _speedClimb = value; } }
    public float SpeedMax { get { return _speedMax; } set { _speedMax = value; } }
    public float SpeedNow { get { return _speedNow; } set { _speedNow = value; } }
    public float Acceleration { get { return _acceleration; } set { _acceleration = value; } }
    public float JumpForce { get { return _jumpForce; } set { _jumpForce = value; } }
    public SpriteAnimationsConfig SpriteAnimationsConfig { get { return _spriteAnimationsConfig; } set { _spriteAnimationsConfig = value; } }
    public CharacterSettings CharacterSettings { get { return _characterSettings; } set { _characterSettings = value; } }

    private CharacterType _characterType;
    private CharacterClass _characterClass;
    private string _description;
    private int _healthMax;
    private int _healthNow;
    private int _damage;
    private float _speedClimb;
    private float _speedMax;
    private float _speedNow;
    private float _acceleration;
    private float _jumpForce;

    private SpriteAnimationsConfig _spriteAnimationsConfig;

    private CharacterSettings _characterSettings;

    public PlayerModel(CharacterData playerData)
    {
        _characterType = playerData.CharacterType;
        _characterClass = playerData.CharacterClass;
        _description = playerData.Description;
        _healthMax = playerData.Health;
        _healthNow = playerData.Health;
        _damage = playerData.Damage;
        _speedClimb = playerData.SpeedClimb;
        _speedMax = playerData.SpeedMax;
        _speedNow = 0; 
        _acceleration = playerData.Acceleration;
        _jumpForce = playerData.JumpForce;
        _spriteAnimationsConfig = playerData.SpriteAnimationsConfig;
        _characterSettings = playerData.CharacterSettings;
    }
}
