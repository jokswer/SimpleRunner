using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    
    private float _oldMousePositionX;
    private float _eulerY;
    
    private static readonly int IsRun = Animator.StringToHash("IsRun");

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool(IsRun, true);
            _oldMousePositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            var newPosition = transform.position + transform.forward * (Time.deltaTime * _speed);
            newPosition.x = Mathf.Clamp(newPosition.x, -2.5f, 2.5f);
            transform.position = newPosition;

            var deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += deltaX;
            _eulerY = Mathf.Clamp(_eulerY, -70, 70);
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool(IsRun, false);
        }
    }
}