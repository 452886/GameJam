using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PhysicsObject : MonoBehaviour
{
    [Header("Physics Object")]
    [SerializeField] float gravity = -20f;
    
    private CharacterController controller;
    private float currentGravity = 0f;
    private Vector3 velocity;

    // Start is called before the first frame update
    public virtual void Start()
    {
        this.controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        UpdateGravity();
        MoveCharacter();
    }

    public void SetVelocity(Vector3 velocity) {
        this.velocity = velocity;
    }

    public void UpdateGravity() {
        currentGravity += gravity * Time.deltaTime;
        
        if(controller.isGrounded) currentGravity = -3f;
        velocity += Vector3.up * currentGravity;
    }

    public void MoveCharacter() {
        this.controller.Move(velocity * Time.deltaTime);
    }
}
