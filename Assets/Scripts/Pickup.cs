
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    protected override void finishInteract(Interacter target)
    {
        
    }

    protected override void interact(Interacter target)
    {
        transform.position = target.transform.position;
        transform.position += new Vector3(0, 1.5f, 0);
        transform.parent = target.transform;
    }
}
