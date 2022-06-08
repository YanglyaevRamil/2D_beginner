using UnityEngine;

public class BuilderPlayer : Builder
{
    public override GameObject GetGO(string s) 
    {
        var go = base.GetGO(s);
        go.name = PlayerCnst.NAME;
        go.AddComponent<PlayerView>();
        go.AddComponent<Rigidbody2D>();

        return go;
    }
}