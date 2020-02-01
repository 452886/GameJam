using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : ItemReceiver
{
    public Cannon()
    {
        keyItem = new CannonBall();
    }
    protected override void interact(Interacter target)
    {
        base.interact(target);
    }
    protected override void finishInteract(Interacter target)
    {
        base.finishInteract(target);
    }

    protected override void execute()
    {
        Debug.Log("kedeng");
    }
}
