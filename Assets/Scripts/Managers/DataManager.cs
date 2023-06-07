using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int life, coin;

    void Awake()
    {
        life = 10;
        coin = 100;
    }
}
