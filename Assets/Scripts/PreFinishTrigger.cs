using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerBehavior = other.attachedRigidbody.GetComponent<PlayerBehavior>();

        if (playerBehavior)
        {
            playerBehavior.StartPreFinishBehavior();
        }
    }
}
