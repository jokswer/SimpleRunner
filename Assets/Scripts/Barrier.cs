using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private GameObject bricksEffectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        var playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if (playerModifier)
        {
            playerModifier.HitBarrier();
            Destroy(gameObject);
            Instantiate(bricksEffectPrefab, transform.position, transform.rotation);
        }
    }
}