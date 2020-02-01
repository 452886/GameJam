using UnityEngine;
using System.Linq;
public class PlayerController : PhysicsObject
{
    [Header("Player Controller")]
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float acceleration = 2f;
    [SerializeField] float deceleration = 5f;
    private Vector3 moveVelocity;

    private float xAxis, yAxis;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        
        GameObject.FindGameObjectsWithTag("Item").Select(x => {
            return x.GetComponent<Collider>();
        }).ToList().ForEach(c => {
            Physics.IgnoreCollision(c, controller);
        });
    }

    // Update is called once per frame
    public override void Update()
    {

        var xAxis = Input.GetAxisRaw("Horizontal");
        var yAxis = Input.GetAxisRaw("Vertical");

        SetVelocity(new Vector3(xAxis, 0f, yAxis).normalized * movementSpeed);
        
        UpdateGravity();
        MoveCharacter();
    }
}
