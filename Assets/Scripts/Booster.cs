using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Interactable
{
    [SerializeField]
    float boostDuration = 5.0f;

    [SerializeField]
    float boostStrength = 5.0f;

    [SerializeField] GameObject hider;
    // BoxCollider bc;

    public override void Start()
    {
        // mr = GetComponent<MeshRenderer>();
        base.Start();
        po = GetComponent<PhysicsObject>();
        // bc = GetComponent<BoxCollider>();
    }
    protected override void finishInteract(Interacter target)
    {
        
    }

    protected override void interact(Interacter target)
    {
        PlayerController playerController = target.GetComponent<PlayerController>();
        if (playerController != null)
        {
            SetActive(false);
            StartCoroutine(buffTimer(target));
        }
    }

    IEnumerator buffTimer(Interacter target)
    {
        PlayerController playerController = target.GetComponent<PlayerController>();
        playerController.SetMovementSpeed(playerController.GetCurrentMovementSpeed() + boostStrength);
        yield return new WaitForSeconds(boostDuration);
        Debug.Log("WaitAndPrint " + Time.time);
        playerController.SetMovementSpeed(playerController.GetCurrentMovementSpeed() - boostStrength);
        Destroy(gameObject);
    }

    void SetActive(bool state)
    {
        hider.SetActive(state);
        this.isActive = state;
    }
}
