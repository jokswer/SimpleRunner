using System;
using UnityEngine;

public enum DeformationType
{
    Width,
    Height
}

public class Gate : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private DeformationType deformationType;
    [SerializeField] private GateAppearance gateAppearance;

    private void OnValidate()
    {
        gateAppearance.UpdateVisual(deformationType, value);
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();

        if (playerModifier)
        {
            if (deformationType == DeformationType.Width)
            {
                playerModifier.AddWidth(value);
            }
            else
            {
                playerModifier.AddHeight(value);
            }
            
            Destroy(gameObject);
        }
    }
}