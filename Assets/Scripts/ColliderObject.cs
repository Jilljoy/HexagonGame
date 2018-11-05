using UnityEngine;

/// <summary>
/// A base ColliderObject for support for multiple shapes.
/// </summary>
public class ColliderObject : MonoBehaviour
{
    protected void Start()
    {
        Setup();
    }

    /// <summary>
    /// Setup this current ColliderObject.
    /// Give it a random z-axis rotation and set it's localScale to 10.
    /// </summary>
    protected void Setup()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        transform.localScale = Vector3.one * 10f;
    }

    /// <summary>
    /// If the GameIsInProgress then decreases the ColliderObject's size and if it's too small calls RemoveObject(true).
    /// Else calls RemoveObject(false)
    /// Called in Update.
    /// </summary>
    /// <param name="shrinkSpeedOfObject"></param>
    protected void CheckIfShouldRemove(float shrinkSpeedOfObject)
    {
        if (GameManager.IsGameInProgress)
        {
            transform.localScale -= Vector3.one * shrinkSpeedOfObject * Time.deltaTime;

            if (transform.localScale.x <= 0.5f)
            {
                RemoveObject(true);
            }
        }
        else
        {
            RemoveObject(false);
        }
    }

    /// <summary>
    /// Remove this ColliderObject and update the CurrentScore, if increaseScore is true.
    /// </summary>
    /// <param name="increaseScore"></param>
    void RemoveObject(bool increaseScore)
    {
        if (increaseScore)
        {
            GameManager.Instance.IncreaseCurrentScore(1);
        }

        Destroy(gameObject);
    }

}
