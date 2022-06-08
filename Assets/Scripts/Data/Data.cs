using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Configs/Data")]
public class Data : ScriptableObject
{
    [SerializeField] private string playerDataPath;
    private PlayerData playerData;

    [SerializeField] private string characterDataPath;
    private CharacterData[] characterData;
    public PlayerData Player
    {
        get
        {
            if (playerData == null)
            {
                playerData = Load<PlayerData>("ScriptableObject/" + playerDataPath);
            }
    
            return playerData;
        }
    }

    public CharacterData[] Character
    {
        get
        {
            if (characterData == null)
            {
                characterData = LoadAll<CharacterData>("ScriptableObject/" + characterDataPath);
            }

            return characterData;
        }
    }

    private T[] LoadAll<T>(string resourcesPath) where T : Object =>
        Resources.LoadAll<T>(Path.ChangeExtension(resourcesPath, null));

    private T Load<T>(string resourcesPath) where T : Object =>
        Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
