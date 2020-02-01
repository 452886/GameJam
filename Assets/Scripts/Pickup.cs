using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    List<ItemTaker> inRangeTakers;

    [SerializeField]
    ItemTaker closestTaker;

    void Start()
    {
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.center = new Vector3(0, -0.5f, 0);
        collider.isTrigger = true;
        collider.radius = 3;
    }

    void Update()
    {
        closestTaker = ClosestInRangeItem();
    }

    //--------------------------------------------------------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------------------------------------------------------

    public void TakerEntersRange(ItemTaker enteringTaker)
    {
        if (!inRangeTakers.Contains(enteringTaker))
            inRangeTakers.Add(enteringTaker);

        enteringTaker.PickupEnterRange(this);
    }

    public void TakerExitsRange(ItemTaker exitingTaker)
    {
        if (inRangeTakers.Contains(exitingTaker))
            inRangeTakers.Remove(exitingTaker);

        exitingTaker.PickupOutOfRange(this);
    }

    //--------------------------------------------------------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------------------------------------------------------

    void OnTriggerEnter(Collider collider)
    {
        ItemTaker inRangeTaker = collider.gameObject.GetComponent<ItemTaker>();
        if (inRangeTaker != null)
        {
            TakerEntersRange(inRangeTaker);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        ItemTaker inRangeTaker = collider.gameObject.GetComponent<ItemTaker>();
        if (inRangeTaker != null)
        {
            TakerExitsRange(inRangeTaker);
        }
        else
        {
            return;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------------------------------------------------------

    public ItemTaker ClosestInRangeItem()
    {
        if (inRangeTakers.Count > 0)
        {
            if (inRangeTakers.Count == 1)
            {
                return inRangeTakers[0];
            }
            else
            {
                float lowestDist = Mathf.Infinity;
                ItemTaker closest = null;

                for (int i = 0; i < inRangeTakers.Count; i++)
                {
                    float current = calcDist(inRangeTakers[i]);
                    if (current < lowestDist)
                    {
                        lowestDist = current;
                        closest = inRangeTakers[i];
                    }
                }

                return closest;
            }
        }else
        {
            return null;
        }
    }

    float calcDist(ItemTaker itemTaker)
    {
        return Vector3.Distance(itemTaker.transform.position, transform.position);
    }

}
