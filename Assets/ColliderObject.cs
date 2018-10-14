using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObject : MonoBehaviour
{
    protected void Setup()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        transform.localScale = Vector3.one * 10f;
    }

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

    void RemoveObject(bool increaseScore)
    {
        if (increaseScore)
        {
            GameManager.Instance.IncreaseCurrentScore(1);
        }

        Destroy(gameObject);
    }

}
