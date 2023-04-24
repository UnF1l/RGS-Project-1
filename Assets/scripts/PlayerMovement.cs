using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode key = KeyCode.LeftShift;
    public float moveSpeed;
    public float accelerationTime;
    public float dashSpeed;
    private float curDashSpeed;

    private enum State
	{
        Normal,
        Dash,
	}

    private Vector2 moveDirection;
    private Vector2 smoothedMovementInput;
    private Vector2 movementInputSmoothVelocity;
    private Vector2 dashDirection;
    private Vector2 lastMoveDirection;
    private State state;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Normal;
    }
    
    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

	private void FixedUpdate()
	{
        Move();
	}

    void GetInputs()
	{
        switch (state)
        {
            case State.Normal:
                float moveX = Input.GetAxisRaw("Horizontal");
                float moveY = Input.GetAxisRaw("Vertical");

                moveDirection = new Vector2(moveX, moveY).normalized;

                if(moveX != 0 || moveY != 0)
				{
                    lastMoveDirection = moveDirection;
				}

                if (Input.GetKeyDown(key))
                {
                    dashDirection = lastMoveDirection;
                    moveDirection = lastMoveDirection;
                    curDashSpeed = dashSpeed;
                    state = State.Dash;
                }
                break;
            case State.Dash:
                float dashSpeedDropMultiplier = 2f;
                curDashSpeed -= curDashSpeed * dashSpeedDropMultiplier * Time.deltaTime;
                float dashSpeedMinimum = 250f; //Напомнить Данзану так не делать
                if (curDashSpeed < dashSpeedMinimum)
                {
                    state = State.Normal;
                }
                break;
        }
	}

	void Move()
	{
        switch (state) {
            case State.Normal:
                smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, moveDirection, ref movementInputSmoothVelocity, accelerationTime);
                rb.velocity = smoothedMovementInput * moveSpeed;
                break;
            case State.Dash:
                rb.velocity = dashDirection * curDashSpeed;
                break;
        }
	}
}
