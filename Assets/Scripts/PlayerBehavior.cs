using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private static readonly int Dance = Animator.StringToHash("Dance");
    
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private PreFinishBehaviour preFinishBehaviour;
    [SerializeField] private Animator animator;

    void Start()
    {
        playerMove.enabled = false;
        preFinishBehaviour.enabled = false;
    }

    public void Play()
    {
        playerMove.enabled = true;
    }

    public void StartPreFinishBehavior()
    {
        playerMove.enabled = false;
        preFinishBehaviour.enabled = true;
    }

    public void StartFinishBehavior()
    {
        preFinishBehaviour.enabled = false;
        animator.SetTrigger(Dance);
    }
}
