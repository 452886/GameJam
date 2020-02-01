
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    [SerializeField]
    List<Interactable> inRangeInteractables;

    void start()
    {
        inRangeInteractables = new List<Interactable>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interactable closest = ClosestInRangeItem();
            if (closest)
            {
                closest.Interact(this);
            }
        }
    }

    public Interactable ClosestInRangeItem()
    {
        if (inRangeInteractables.Count > 0)
        {
            if (inRangeInteractables.Count == 1)
            {
                return inRangeInteractables[0];
            }
            else
            {
                float lowestDist = Mathf.Infinity;
                Interactable closest = null;
                for (int i = 0; i < inRangeInteractables.Count; i++)
                {
                    float current = calcDist(inRangeInteractables[i].transform);
                    if (current < lowestDist)
                    {
                        lowestDist = current;
                        closest = inRangeInteractables[i];
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


    public virtual void InteractableEntersRange(Interactable interactable)
    {
        if (!inRangeInteractables.Contains(interactable))
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
        }
        Debug.Log("item exited range: " + interactable.name);
    }
}
