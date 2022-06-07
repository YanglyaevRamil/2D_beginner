using UnityEngine;

public class Builder
{
    private GameObject _GO;

    public Builder(string s)
    {
        _GO = Object.Instantiate(Resources.Load<GameObject>(s));
    }

    public virtual GameObject GetGO()
    {
        _GO.AddComponent<SpriteRenderer>();
        _GO.AddComponent<Rigidbody2D>();

        return _GO;
    }
}