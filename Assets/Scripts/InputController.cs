using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputController : MonoBehaviour
{
    [Header("Character Input Values")]
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;
    
    //is our character attacking?
    public bool attack;

    // are we performing an action?
    public bool interact;

    [Header("Movement Settings")]
    public bool analogMovement;

    [Header("Mouse Cursor Settings")]
    public bool cursorLocked = true;
    public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (cursorInputForLook)
        {
            LookInput(context.ReadValue<Vector2>());
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            JumpInput(true);
        else 
            JumpInput(false);
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        ButtonControl button = context.control as ButtonControl;
        if (button.wasPressedThisFrame)
        {
            SprintInput(true);
        }
        else if(button.wasReleasedThisFrame)
        {
            SprintInput(false);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackInput(true);
        }
        
        if(context.canceled)
        {
            AttackInput(false);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        ButtonControl button = context.control as ButtonControl;

        if (button.wasPressedThisFrame)
        {
            Interaction(true);
        }
        else
        {
            Interaction(false);
        }
        //print(context.phase);
        // if (context.performed)
        //    Interaction(true);
        //else
        //    Interaction(false);
    }
#endif


    public void MoveInput(Vector2 newMoveDirection)
    {
        move = newMoveDirection;
    }

    public void LookInput(Vector2 newLookDirection)
    {
        look = newLookDirection;
    }

    public void JumpInput(bool newJumpState)
    {
        jump = newJumpState;
    }

    public void SprintInput(bool newSprintState)
    {
        sprint = newSprintState;
    }

    public void AttackInput(bool isAttacking)
    {
        attack = isAttacking;
    }

    private void Interaction(bool isInteracting)
    {
        print("interaction pressed");   
        interact = isInteracting;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        SetCursorState(cursorLocked);
    }

    private void SetCursorState(bool newState)
    {
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }
}
