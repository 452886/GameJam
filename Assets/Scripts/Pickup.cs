using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    List<ItemTaker> inRangeTakers;

    [SerializeField]
    ItemTaker closestTaker;

    bool isTaken = false;

    void Start()
    {
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.center = new Vector3(0, -0.5f, 0);
        collider.isTrigger = true;
        collider.radius = 3;
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

    public void Take(ItemTaker target)
    {
        if (!isTaken)
        {
            isTaken = true;
            take(target);
        }
    }

    protected abstract void take(ItemTaker target);

}
