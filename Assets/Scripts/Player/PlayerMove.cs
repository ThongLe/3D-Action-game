using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;

    public float walkspeed = 10f;
    public float flyspeed = 20f;
    public float jumpHeight = 3f;
    public float acceleration = 20f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;

    PlayerInput playerInput;
    InputAction moveAction;
    InputAction sprintAction;
    InputAction jumpAction;

    public State state; 
    public enum State
    {
        Walking,
        Flying
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["move"];
        sprintAction = playerInput.actions["sprint"];
        jumpAction = playerInput.actions["jump"];
    }

    void Update()
    {
        switch (state)
        {
            case State.Walking:
                CheckGravity();
                UpdateMovement();
                break;
            case State.Flying:
                UpdateMovementFly();
                break;
        }
        
    }

    void CheckGravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        var gravity = Physics.gravity * 2 * Time.deltaTime;

        /*if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }*/

        velocity.y = isGrounded ? -2f : velocity.y + gravity.y ;

    }

    Vector3 GetMovementInput(float speed, bool horizontal = true)
    {
        var moveInput = moveAction.ReadValue<Vector2>();

        var input = new Vector3();
        input += transform.forward * moveInput.y;
        input += transform.right * moveInput.x;
        input = Vector3.ClampMagnitude(input, 1f);

        var sprintInput = sprintAction.ReadValue<float>();
        var multiplier = sprintInput > 0 ? 2f : 1f;

        input *= speed * multiplier;

        return input;
    }

    void UpdateMovement()
    {
        var input = GetMovementInput(walkspeed);

        var factor = acceleration * Time.deltaTime;
        velocity.x = Mathf.Lerp(velocity.x, input.x, factor);
        velocity.z = Mathf.Lerp(velocity.z, input.z, factor);

        var jumpInput = jumpAction.ReadValue<float>();
        if (jumpInput > 0 && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * (-9.81f * 2));
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void UpdateMovementFly()
    {
        var input = GetMovementInput(flyspeed, false);

        var factor = acceleration * Time.deltaTime;
        velocity = Vector3.Lerp(velocity, input, factor);

        var jumpInput = jumpAction.ReadValue<float>();
        if (jumpInput > 0)
        {
            velocity.y += 1;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    void OnToggleFlying()
    {
        state = state == State.Flying ? State.Walking : State.Flying;
    }
}
