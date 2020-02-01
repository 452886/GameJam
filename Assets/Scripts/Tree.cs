using UnityEngine;
using UnityEngine.UI;

public class Tree : Interactable
{

    [SerializeField] float duration = 5f;
    [SerializeField] float respawnDuration = 10f;
    [SerializeField] GameObject treeMesh;
    [SerializeField] Slider slider;
    [SerializeField] GameObject sliderUI;

    private float currentDuration;
    private float currentRespawnDuration = 0f;

    bool interacting = false;
    protected override void interact(Interacter target)
    {
        interacting = true;
    }

    protected override void finishInteract(Interacter target)
    {
        interacting = false;
    }

    void Start()
    {
        slider.maxValue = duration;
    }

    void Update()
    {
        if(isActive) {
            if(interacting) {
                sliderUI.SetActive(true);
                currentDuration += Time.deltaTime;
            }
            else {
                currentDuration = 0f;
                sliderUI.SetActive(false);
            }

            if(currentDuration >= duration) {
                currentDuration = 0f;
                isActive = false;
                treeMesh.SetActive(false);
            }
        } else {
            sliderUI.SetActive(false);
            currentRespawnDuration += Time.deltaTime;
            if(currentRespawnDuration >= respawnDuration) {
                isActive = true;
                currentRespawnDuration = 0f;
                treeMesh.SetActive(true);
            }
        }
        slider.value = currentDuration;
    }

}
