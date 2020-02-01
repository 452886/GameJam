using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PhysicsObject : MonoBehaviour
{
    [Header("Physics Object")]
    [SerializeField] float gravity = -20f;

    protected CharacterController controller;
    private float currentGravity = 0f;
    private Vector3 velocity;

    private bool gravityEnabled = true;

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

    public void DisableGravity() {
        this.gravityEnabled = false;
    }

    public void EnableGravity() {
        this.gravityEnabled = true;
    }

    public void UpdateGravity() {
        currentGravity += gravityEnabled ? gravity * Time.deltaTime : 0f;
        
        if(controller.isGrounded) currentGravity = -3f;
        velocity = velocity + Vector3.up * currentGravity;
    }

    public void MoveCharacter() {
        this.controller.Move(velocity * Time.deltaTime);
    }
}
