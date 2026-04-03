using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls controls;
    [SerializeField] private bool moveKeyHeld;
    private void Awake()=>
        controls = new Controls();
    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Movement.performed += onMovement;
        controls.Player.Movement.canceled += onMovement;
        controls.Player.Exit.performed += onExit;
    }
    private void OnDisable()
    {
        controls.Disable();
        controls.Player.Movement.performed -= onMovement;
        controls.Player.Movement.canceled -= onMovement;
        controls.Player.Exit.performed -= onExit;
    }
    private void onMovement(InputAction.CallbackContext context)
    {
      if(context.performed)
        {
            moveKeyHeld = true;
        }
      else if(context.canceled)
        {
            moveKeyHeld = false;
        }
    }
    private void onExit(InputAction.CallbackContext context)
    {
        Debug.Log("Exit");
    }
    private void FixedUpdate()
    {
        if(GameManager.Instance.IsPlayerTurn && moveKeyHeld)
        {
            MovePlayer();
        }   
    }
    private void MovePlayer()
    {
       transform.position += (Vector3)controls.Player.Movement.ReadValue<Vector2>();
       GameManager.Instance.EndPlayerTurn();
    }
}
