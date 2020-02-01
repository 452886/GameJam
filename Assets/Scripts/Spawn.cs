using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    GameObject currentItem;

    public void FillSpawn(GameObject item)
    {
        currentItem = item;
    }

    public GameObject CurrentItem
    {
        get { return currentItem; }
    }
    public void ClearItem()
    {
        this.currentItem = null;
    }
}
