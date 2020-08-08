using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementOffset = 5;
    
    private InputMaster _controls;
    private Vector2 _movement;

    public void Awake()
    {
        _controls = new InputMaster();
        _controls.Player.Movement.performed += ctx => _movement = ctx.ReadValue<Vector2>();
    }

    public void FixedUpdate()
    {
        transform.position += new Vector3(_movement.x * movementOffset * Time.deltaTime, 0, _movement.y * movementOffset * Time.deltaTime);
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
