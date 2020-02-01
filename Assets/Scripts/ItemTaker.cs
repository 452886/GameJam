
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pickup closest = ClosestInRangeItem();
            if (closest)
            {
                closest.Take(this);
            }
        }
    }

    public Pickup ClosestInRangeItem()
    {
        if (inRangePickups.Count > 0)
        {
            if (inRangePickups.Count == 1)
            {
                return inRangePickups[0];
            }
            else
            {
                float lowestDist = Mathf.Infinity;
                Pickup closest = null;
                for (int i = 0; i < inRangePickups.Count; i++)
                {
                    float current = calcDist(inRangePickups[i].transform);
                    if (current < lowestDist)
                    {
                        lowestDist = current;
                        closest = inRangePickups[i];
                    }
                }

                return closest;
            }
        }
        else
        {
            return null;
        }
    }

    float calcDist(Transform tf)
    {
        return Vector3.Distance(tf.position, transform.position);
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
