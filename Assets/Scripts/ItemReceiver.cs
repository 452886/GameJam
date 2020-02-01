using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemReceiver : Interactable
{
    protected Pickup keyItem;
    protected override void finishInteract(Interacter target)
    {

    }
    protected override void interact(Interacter target)
    {
        if (target.carryItem != null)
        {
            Debug.Log(target.GetType() + "" + keyItem.GetType());
            if (target.CarriedItem.GetType() == keyItem.GetType())
            {
                target.RemoveCarriedItem();
                execute();
            }
        }
    }

    protected abstract void execute();
}
