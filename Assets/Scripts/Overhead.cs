
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overhead : Pickup
{
    protected override void take(ItemTaker target)
    {
        transform.position = target.transform.position;
        transform.position += new Vector3(0, 1.5f, 0);
        transform.parent = target.transform;
    }
}
