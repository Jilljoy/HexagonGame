using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed;

    void Update()
    {
        if (GameManager.IsGameInProgress)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
        }

    }
}
