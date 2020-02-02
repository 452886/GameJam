using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : ItemReceiver
{
    public Ship()
    {
        keyItem = new Wood();
    }
    int progress = 0;

    


    protected override void execute()
    {
        Debug.Log("building ship");
        progress++;
    }
}
