using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    List<Interacter> inRangeUsers;

    bool isBeingUsed = false;

    void Start()
    {
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.center = new Vector3(0, -0.5f, 0);
        collider.isTrigger = true;
        collider.radius = 3;        //radius of the trigger is manually set here for now
    }

    //--------------------------------------------------------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------------------------------------------------------

    void userEntersRange(Interacter enteringTaker)
    {
        if (!inRangeUsers.Contains(enteringTaker))
            inRangeUsers.Add(enteringTaker);

        enteringTaker.InteractableEntersRange(this);
    }

    void usererExitsRange(Interacter exitingTaker)
    {
        if (inRangeUsers.Contains(exitingTaker))
            inRangeUsers.Remove(exitingTaker);

        exitingTaker.InteractableExitsRange(this);
    }

    //--------------------------------------------------------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------------------------------------------------------

    void OnTriggerEnter(Collider collider)
    {
        Interacter inRangeTaker = collider.gameObject.GetComponent<Interacter>();
        if (inRangeTaker != null)
        {
            userEntersRange(inRangeTaker);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        Interacter inRangeTaker = collider.gameObject.GetComponent<Interacter>();
        if (inRangeTaker != null)
        {
            usererExitsRange(inRangeTaker);
        }
        else
        {
            return;
        }
    }
    //--------------------------------------------------------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------------------------------------------------------

    public void Interact(Interacter target)
    {
        if (!isBeingUsed)
        {
            isBeingUsed = true;
            interact(target);
        }
    }

    protected abstract void interact(Interacter target);

}
