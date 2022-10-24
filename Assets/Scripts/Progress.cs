using UnityEngine;

public class Progress : MonoBehaviour
{
    private int _coins;
    private int _width;
    private int _height;

    public int Coins
    {
        get => _coins;
        set
        {
            if (value > 0)
            {
                _coins = value;
            }
        }
    }

    public int Width
    {
        get => _width;
        set
        {
            if (value > 0)
            {
                _width = value;
            }
        }
    }

    public int Height
    {
        get => _height;
        set
        {
            if (value > 0)
            {
                _height = value;
            }
        }
    }

    public static Progress Instance => _instance;
    private static Progress _instance;

    void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            _instance = this;
        }
    }
}