using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageTrap : Interactable
{
    [SerializeField] GameObject cage;
    [SerializeField] float cageHeight = 10f;
    [SerializeField] float trapDuration = 2f;

    private float currentTrapDuration = 0f;
    private bool trapArmed = false;
    private bool trapActivated = false;
    private ActivePlayer trapOwner;

    private PlayerController trappedPlayer;
    
    public void ArmTrap(ActivePlayer player) {
        trapArmed = true;
        trapOwner = player;
    }

    public override void Start()
    {
        base.Start();
        po = GetComponentInChildren<PhysicsObject>();
        cage.GetComponent<Renderer>().enabled = false;
        cage.transform.position = new Vector3(cage.transform.position.x, cage.transform.position.y + cageHeight, cage.transform.position.z);
        cage.GetComponent<PhysicsObject>().DisableGravity();
        ArmTrap(ActivePlayer.PLAYER2);
    }

    protected override void finishInteract(Interacter target){}

    protected override void interact(Interacter target)
    {
        if(!trapArmed) return;
        if(target.tag == "Player") {
            var pc = target.GetComponent<PlayerController>();
            if(pc.activePlayer == trapOwner) return;
            pc.DisableMovement();
            cage.GetComponent<Renderer>().enabled = true;
            cage.GetComponent<PhysicsObject>().EnableGravity();
            trappedPlayer = pc;
            trapActivated = true;
        }
    }

    void Update()
    {
        if(trapActivated) {
            currentTrapDuration += Time.deltaTime;
            if(currentTrapDuration >= trapDuration) {
                trappedPlayer.EnableMovement();
                trappedPlayer = null;
                Destroy(gameObject);
            }
        }
    }
}
