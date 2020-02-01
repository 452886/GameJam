using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField]
    List<Interacter> inRangeUsers;
    public bool isActive = true;

    bool isBeingUsed = false;

    void Start()
    {
        SphereCollider collider = gameObject.GetComponent<SphereCollider>();
    }

    //--------------------------------------------------------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------------------------------------------------------

    void userEntersRange(Interacter enteringInteractor)
    {
        if (!inRangeUsers.Contains(enteringInteractor))
            inRangeUsers.Add(enteringInteractor);

        enteringInteractor.InteractableEntersRange(this);
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

    public void FinishInteract(Interacter target) {
        finishInteract(target);
        isBeingUsed = false;
    }

    protected abstract void interact(Interacter target);
    protected abstract void finishInteract(Interacter target);

}
