using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Configs/Data")]
public class Data : ScriptableObject
{
    [SerializeField] private string characterPrefPath;

    [SerializeField] private string characterDataPath;
    private CharacterData[] characterData;

    public CharacterData[] Character
    {
        get
        {
            if (characterData == null || characterData.Length == 0)
            {
                characterData = LoadAll<CharacterData>(characterDataPath);
            }

            return characterData;
        }
    }

    public string CharacterPrefPath { get { return characterPrefPath; } }

    private T[] LoadAll<T>(string resourcesPath) where T : Object =>
        Resources.LoadAll<T>(Path.ChangeExtension(resourcesPath, null));

    private T Load<T>(string resourcesPath) where T : Object =>
        Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
