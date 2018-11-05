using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    float lifetime = 1f;
    [SerializeField]
    SpriteRenderer attachedImage;
    PickupType thisPickUpType { get; set; }

    public void Setup(PickupType pickupType, float newLifetime = 1f)
    {
        lifetime = newLifetime;

        thisPickUpType = pickupType;

        SetColour(Color.red);

        Destroy(this, lifetime);
    }

    private void SetColour(Color newColour)
    {
        attachedImage.color = newColour;
    }

    //private void OnTriggerEnter(Collider collision)
    //{
    //    Debug.LogWarning("Pickup collided with " + collision.tag);
    //    if (collision.tag.Equals("Player", System.StringComparison.OrdinalIgnoreCase))
    //    {
    //        GameManager.Instance.PickupCollected(thisPickUpType);

    //        Destroy(this);
    //    }

    //}

}
