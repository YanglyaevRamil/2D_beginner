using UnityEngine;

public class CoinView : MonoBehaviour, ICoinProvider
{
    [SerializeField]
    private int _price;

    public int Price { get { return _price; } set { _price = value; } }
}
