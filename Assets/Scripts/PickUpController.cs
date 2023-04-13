using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    void Start()
    {
        BulletTrigger.OnPickupCollected += OnPickupCollected;
    }

    void OnDestroy()
    {
        BulletTrigger.OnPickupCollected -= OnPickupCollected;
    }

    void OnPickupCollected()
    {
        Debug.Log("Pickup collected by player");
    }

}
