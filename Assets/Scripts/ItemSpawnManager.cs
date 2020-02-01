using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField]
    List<itemInfo> availableInteracts = new List<itemInfo>();
    List<itemInfo> unavailableInteracts = new List<itemInfo>();
    GameObject[] spawns;

    int nrOfPickups = 0;
    int nrOfBoosters = 0;


    void Start()
    {
        findAllSpawns();
        populateSpawns();
    }

    void findAllSpawns()
    {
        spawns = GameObject.FindGameObjectsWithTag("Spawn");
    }

    void populateSpawns()
    {

        foreach (GameObject spawn in spawns)
        {
            if (availableInteracts.Count > 0)
            {
                var random = availableInteracts[Random.Range(0, availableInteracts.Count)];

                switch (random.type)
                {
                    case ItemType.BOOSTER:
                        nrOfBoosters++;
                        if (nrOfBoosters >= random.spawnLimit)
                        {
                            availableInteracts.Remove(random);
                            unavailableInteracts.Add(random);
                        }
                        break;

                    case ItemType.PICKUP:
                        nrOfPickups++;
                        if (nrOfPickups >= random.spawnLimit)
                        {
                            availableInteracts.Remove(random);
                            unavailableInteracts.Add(random);
                        }
                        break;
                }

                GameObject go = Instantiate(random.item);
                go.transform.position = spawn.transform.position;
            }
        }
    }
}

[System.Serializable]
public enum ItemType
{
    BOOSTER, PICKUP
}

[System.Serializable]
public struct itemInfo
{
    public string name;
    public GameObject item;
    public ItemType type;
    public int spawnLimit;
}


