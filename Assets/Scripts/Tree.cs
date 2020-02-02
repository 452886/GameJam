using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class Tree : Interactable
{

    [SerializeField] float duration = 5f;
    private float respawnDuration;

    [SerializeField] float respawnMin, respawnMax;
    [SerializeField] GameObject treeMesh;

    private float currentDuration;
    private float currentRespawnDuration = 0f;
    bool interacting = false;

    // Slider
    [SerializeField] Transform sliderposition;
    [SerializeField] GameObject treeSliderPrefab;
    [SerializeField] Transform canvas;
    private GameObject spawnedTreeSlider;
    private Slider slider;

    private Interacter chopper;
    private List<ShipProgress> ships;


    public override void Start()
    {
        respawnDuration = Random.Range(respawnMin, respawnMax);
        po = GetComponent<PhysicsObject>();
        spawnedTreeSlider = Instantiate(treeSliderPrefab);
        spawnedTreeSlider.transform.parent = canvas;
        
        slider = spawnedTreeSlider.GetComponent<Slider>();

        slider.maxValue = duration;
        spawnedTreeSlider.SetActive(false);

        ships = GameObject.FindGameObjectsWithTag("Ship").ToList().Select(ship => {
            return ship.GetComponent<ShipProgress>();
        }).ToList();
    }

    protected override void interact(Interacter target)
    {
        this.chopper = target;
        interacting = true;
    }

    protected override void finishInteract(Interacter target)
    {
        this.chopper = null;
        interacting = false;
    }

    void Update()
    {
        if(isActive) {
            if(interacting) {
                UpdatSliderPosition();
                spawnedTreeSlider.SetActive(true);
                currentDuration += Time.deltaTime;
            }
            else {
                currentDuration = 0f;
                spawnedTreeSlider.SetActive(false);
            }

            if(currentDuration >= duration) {
                currentDuration = 0f;
                isActive = false;
                treeMesh.SetActive(false);

                this.ships.ForEach(ship => {
                    if(ship.team == this.chopper.GetComponent<PlayerController>().team) ship.AddRepairPoints(1);
                });
            }
        } else {
            spawnedTreeSlider.SetActive(false);
            currentRespawnDuration += Time.deltaTime;
            if(currentRespawnDuration >= respawnDuration) {
                isActive = true;
                currentRespawnDuration = 0f;
                respawnDuration = Random.Range(respawnMin, respawnMax);
                treeMesh.SetActive(true);
            }
        }
        slider.value = currentDuration;
    }

    public void UpdatSliderPosition() {
        Vector3 pos = Camera.main.WorldToScreenPoint(sliderposition.position);
        spawnedTreeSlider.transform.position = pos;
    }

}
