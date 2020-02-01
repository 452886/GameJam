using UnityEngine;
using System.Linq;
public class PlayerController : PhysicsObject
{
    [Header("Player Controller")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float deceleration = 5f;
    public ActivePlayer activePlayer = ActivePlayer.PLAYER1;
    private Vector3 moveVelocity;

    private float currentMovementSpeed = 5f;
    private float xAxis, yAxis;
    private bool movingDisabled = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        currentMovementSpeed = movementSpeed;
        GameObject.FindGameObjectsWithTag("Item").Select(x => {
            return x.GetComponent<Collider>();
        }).ToList().ForEach(c => {
            Physics.IgnoreCollision(c, controller);
        });
    }

    public void SetMovementSpeed(float ms) {
        this.currentMovementSpeed = ms;
    }

    public void ResetMovementSpeed() {
        this.currentMovementSpeed = movementSpeed;
    }

    public float GetCurrentMovementSpeed() {
        return currentMovementSpeed;
    }

    public float GetDefaultSpeed() {
        return movementSpeed;
    }

    public void DisableMovement() {
        this.movingDisabled = true;
    }

    public void EnableMovement() {
        this.movingDisabled = false;
    }

    public bool isMovementDisabled() {
        return this.movingDisabled;
    }

    // Update is called once per frame
    public override void Update()
    {

        var xAxis = movingDisabled ? 0 : Input.GetAxisRaw(ActivePlayerData.Horizontal(activePlayer));
        var yAxis = movingDisabled ? 0 : Input.GetAxisRaw(ActivePlayerData.Vertical(activePlayer));

        SetVelocity(new Vector3(xAxis, 0f, yAxis).normalized * currentMovementSpeed);
        
        UpdateGravity();
        MoveCharacter();
    }
}