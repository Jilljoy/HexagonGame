using UnityEngine;

public class Rotator : MonoBehaviour
{
    /// <summary>
    /// How fast to rotate the attached GameObject by.
    /// </summary>
    public float rotateSpeed;

    void Update()
    {
        if (GameManager.IsGameInProgress)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
        }

    }
}
