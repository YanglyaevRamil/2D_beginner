using UnityEngine;

internal sealed class LoaderPrefabs
{
    private GameObject[] _prefs;
    public LoaderPrefabs(string path)
    {
        _prefs = Resources.LoadAll<GameObject>(path);
    }

    public GameObject GetGO(CharacterType characterType)
    {
        for (int i = 0; i < _prefs.Length; i++)
        {
            if (i == (int)characterType)
                return Object.Instantiate(_prefs[i]);
        }
        return null;
    }
}