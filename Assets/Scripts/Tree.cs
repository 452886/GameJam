using UnityEngine;
using UnityEngine.UI;

public class Tree : Interactable
{

    [SerializeField] float duration = 5f;
    [SerializeField] float respawnDuration = 10f;
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


    void Start()
    {
        spawnedTreeSlider = Instantiate(treeSliderPrefab);
        spawnedTreeSlider.transform.parent = canvas;
        
        slider = spawnedTreeSlider.GetComponent<Slider>();

        slider.maxValue = duration;
        spawnedTreeSlider.SetActive(false);
    }

    protected override void interact(Interacter target)
    {
        interacting = true;
    }

    protected override void finishInteract(Interacter target)
    {
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
            }
        } else {
            spawnedTreeSlider.SetActive(false);
            currentRespawnDuration += Time.deltaTime;
            if(currentRespawnDuration >= respawnDuration) {
                isActive = true;
                currentRespawnDuration = 0f;
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
