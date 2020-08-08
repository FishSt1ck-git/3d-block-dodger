using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sidewayMovementOffset = 5;
    public float forwardMovementOffset = 5;
    public Rigidbody player;

    private InputMaster _controls;
    private Vector2 _movement;

    public void Awake()
    {
        _controls = new InputMaster();
        _controls.Player.Movement.performed += ctx => _movement = ctx.ReadValue<Vector2>();
    }

    public void FixedUpdate()
    {
        player.AddForce(_movement.x * forwardMovementOffset * Time.deltaTime, 0, _movement.y * sidewayMovementOffset * Time.deltaTime, ForceMode.VelocityChange);

        if(player.transform.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void OnEnable()
    {
        _controls.Player.Movement.Enable();
    }

    public void OnDisable()
    {
        _controls.Player.Movement.Disable();
    }
}
