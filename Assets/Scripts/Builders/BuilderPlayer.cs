using UnityEngine;

public class BuilderPlayer : Builder
{
    public BuilderPlayer(string s) : base(s)
    {

    }

    public override GameObject GetGO()
    {
        var GO = base.GetGO();
        GO.AddComponent<PlayerView>();

        return GO;
    }
}