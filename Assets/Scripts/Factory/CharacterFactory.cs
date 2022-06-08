using UnityEngine;

public class CharacterFactory
{
    private GameObject[] _GO;

    public CharacterFactory(string s)
    {
        _GO = Resources.LoadAll<GameObject>(s);
    }

    public virtual GameObject GetGO(CharacterType characterType)
    {
        return BildGO(_GO[(int)characterType]);
    }

    private GameObject BildGO(GameObject go)
    {
        go.AddComponent<SpriteRenderer>();
        go.AddComponent<Rigidbody2D>();

        return go;
    }
}