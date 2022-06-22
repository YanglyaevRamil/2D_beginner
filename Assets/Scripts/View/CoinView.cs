using UnityEngine;

public class CoinView : MonoBehaviour, ICoinProvider
{
    [SerializeField]
    private int _price;

    public int CoinPrice { get { return _price; } set { _price = value; } }
}
