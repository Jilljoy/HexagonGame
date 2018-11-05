using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// The player's movement speed.
    /// </summary>
    public float movementSpeed = 100f;
    /// <summary>
    /// The players inputDirection, 1f or -1f.
    /// </summary>
    public float inputDirection = 1f;
    /// <summary>
    /// The Axis "Horizontal" from the Input.
    /// </summary>
    float HorizontalInput { get; set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -movementSpeed * Time.fixedDeltaTime * HorizontalInput * inputDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.GameOver();

    }
}
