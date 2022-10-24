using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerBehavior = other.attachedRigidbody.GetComponent<PlayerBehavior>();

        if (playerBehavior)
        {
            playerBehavior.StartFinishBehavior();
            FindObjectOfType<GameManager>().ShowFinishWindow();
        }
    }
}
