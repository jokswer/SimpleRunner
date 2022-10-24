using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{
    void Update()
    {
        var x = Mathf.MoveTowards(transform.position.x, 0, 2f * Time.deltaTime);
        var z = transform.position.z + 3f * Time.deltaTime;
        transform.position = new Vector3(x, 0, z);

        var rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, 100f * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, rot, 0);
    }
}