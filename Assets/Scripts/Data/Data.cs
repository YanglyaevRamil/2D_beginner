using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Data", order = 51)]
public class Data : ScriptableObject
{
    [SerializeField] private string playerDataPath;
    private PlayerData[] playerData;
    public PlayerData[] Player
    {
        get
        {
            if (playerData == null)
            {
                playerData = LoadAll<PlayerData>("ScriptableObject/" + playerDataPath);
            }
    
            return playerData;
        }
    }

    private T[] LoadAll<T>(string resourcesPath) where T : Object =>
        Resources.LoadAll<T>(Path.ChangeExtension(resourcesPath, null));

    private T Load<T>(string resourcesPath) where T : Object =>
        Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
