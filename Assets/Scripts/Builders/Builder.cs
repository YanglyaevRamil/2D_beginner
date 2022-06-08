using UnityEngine;

public class Builder 
{
    public virtual GameObject GetGO(string s)
    {
        Debug.Log(Resources.Load<GameObject>(s));
        return Object.Instantiate(Resources.Load<GameObject>(s));
    }
}