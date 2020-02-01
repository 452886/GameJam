
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    [SerializeField]
    List<Pickup> inRangePickups;

    void start()
    {
        inRangePickups = new List<Pickup>();
    }
    public virtual void PickupEnterRange(Pickup pickup)
    {
        if (!inRangePickups.Contains(pickup))
        {
            inRangePickups.Add(pickup);
            Debug.Log("item entered range: " + inRangePickups.Count + " items in range");
        }
    }

    public virtual void PickupInRange(Pickup pickup)
    {
        Debug.Log("item is in range: " + pickup.name);

    }

    public virtual void PickupOutOfRange(Pickup pickup)
    {
        if (inRangePickups.Contains(pickup))
        {
            inRangePickups.Remove(pickup);
        }
        Debug.Log("item exited range: " + pickup.name);
    }
}
