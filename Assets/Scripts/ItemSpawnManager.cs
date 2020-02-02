
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField]
    List<itemInfo> availableInteracts = new List<itemInfo>();
    [SerializeField] int maxPowerupsPresent = 3;
    List<SpawnInfo> spawns;
    Dictionary<itemInfo, int> activeItems = new Dictionary<itemInfo, int>();

    [SerializeField] float minSpawnTimer, maxSpawnTimer;

    private float spawnTimer;
    private float currentSPawnTimer = 0f;


    void Start()
    {
        findAllSpawns();
        spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
        availableInteracts.ForEach(ai => {
            activeItems.Add(ai, 0);
        });
        
        SpawnItem(availableInteracts[0]);

    }

    void Update()
    {
        if(activeItems.ToList().Sum(kv => {
            return kv.Value;
        }) < maxPowerupsPresent) {
            currentSPawnTimer += Time.deltaTime;
            if(currentSPawnTimer >= spawnTimer) {
                currentSPawnTimer = 0;
                spawnTimer = Random.Range(minSpawnTimer, maxSpawnTimer);
                var spawnableItems = activeItems.ToList().Where(ai => {
                    return activeItems[ai.Key] < ai.Key.spawnLimit;
                }).ToList();
                if(spawnableItems.Count > 0) {
                    SpawnItem(spawnableItems[Random.Range(0, spawnableItems.Count)].Key);
                }
            }
        } else {
            currentSPawnTimer = 0;
        }
    }

    void findAllSpawns()
    {
        spawns = GameObject.FindGameObjectsWithTag("Spawn").Select(spawn => {
            return new SpawnInfo(spawn.transform);
        }).ToList();
    }

    void SpawnItem(itemInfo item) {
        var availableSpawns = spawns.ToList().Where(x => {
            return x.itemOnSpawnpoint == null; //!x.used;
        }).ToList();
        
        var random = availableSpawns[Random.Range(0, availableSpawns.Count)];
        
        random.itemOnSpawnpoint = item;
        var go = Instantiate(item.item);
        go.GetComponent<Interactable>().spawnpoint = random;
        go.transform.position = random.spawnPosition.position;
        activeItems[item]++;
    }

    public void FreeSpawnpoint(SpawnInfo info) {
        activeItems[info.itemOnSpawnpoint.Value]--;
        info.itemOnSpawnpoint = null;
    }
}

[System.Serializable]
public enum ItemType
{
    BOOSTER, WOOD, CANNONBALL
}

[System.Serializable]
public struct itemInfo
{
    public string name;
    public Interactable item;
    public ItemType type;
    public int spawnLimit;
}

[System.Serializable]
public class SpawnInfo {
    public Transform spawnPosition;
    // public bool used = false;
    public itemInfo? itemOnSpawnpoint = null;

    public SpawnInfo(Transform spawnPosition) {
        this.spawnPosition = spawnPosition;
    }
}


