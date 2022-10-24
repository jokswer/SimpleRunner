using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360;
    
    private CoinManager _coinManager;

    void Start()
    {
        _coinManager = FindObjectOfType<CoinManager>();
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        _coinManager.AddOne();
        Destroy(gameObject);
    }
}
