using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    public float movementSpeed = 100f;
    public float inputDirection = 1f;
    float HorizontalInput { get; set; }

    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        //HorizontalInput = Input.GetAxis("Mouse X");
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
