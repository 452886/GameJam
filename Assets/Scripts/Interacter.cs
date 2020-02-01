
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    [SerializeField]
    List<Interactable> inRangeInteractables;
    
    [SerializeField] ActivePlayer activePlayer;

    private Pickup carryItem = null;
    private Interactable closest;

    void start()
    {
        inRangeInteractables = new List<Interactable>();
    }

    void Update()
    {
        if (Input.GetButtonDown(ActivePlayerData.Fire(activePlayer)))
        {
            this.closest = ClosestInRangeItem();
            if (this.closest)
            {
                carryItem = closest is Pickup ? (Pickup)closest : null;
                closest.Interact(this);
            }
        }


        if(Input.GetButtonUp(ActivePlayerData.Fire(activePlayer)))
        {
            if (this.closest)
            {
                this.closest.FinishInteract(this);
            }
        }
    }

    public Interactable ClosestInRangeItem()
    {
        if (inRangeInteractables.Count > 0)
        {
            float lowestDist = Mathf.Infinity;
            closest = null;
            for (int i = 0; i < inRangeInteractables.Count; i++)
            {
                float current = calcDist(inRangeInteractables[i].transform);
                if (current < lowestDist && inRangeInteractables[i].isActive)
                {
                    lowestDist = current;
                    closest = inRangeInteractables[i];
                }
            }
            return closest;
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


    public virtual void InteractableEntersRange(Interactable interactable)
    {
        if (interactable is Booster || interactable is CageTrap)
        {
            interactable.Interact(this);
        }
        else if (!inRangeInteractables.Contains(interactable))
        {
            inRangeInteractables.Add(interactable);
            Debug.Log("item entered range: " + inRangeInteractables.Count + " items in range");

        }
    }

    public virtual void InteractableIsInRange(Interactable interactable)
    {
        Debug.Log("item is in range: " + interactable.name);

    }

    public virtual void InteractableExitsRange(Interactable interactable)
    {
        if (inRangeInteractables.Contains(interactable))
        {
            inRangeInteractables.Remove(interactable);
            if (interactable == this.closest) this.closest.FinishInteract(this);
        }
        Debug.Log("item exited range: " + interactable.name);
    }
}
