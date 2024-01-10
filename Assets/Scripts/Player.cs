using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    public float moveSpeed = 8f;
    public float jumpForce = 8f;
    public float wallJumpForce = 5f;
    public float AirMovementPenealty = .5f;
    

    [Header("DashInfo")]
    public float dashSpeed;
    public float dashDuration;
	[SerializeField] private float dashCooldown;
	public float dashDir { get; private set; }

	#region Collision info
	[Header("collision info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask groundLayer;
    #endregion

    public int facingDir { get; private set; } = 1;
    private bool facingRight = true;

	#region States
	public PlayerStateMachine stateMachine {  get; private set; }
    public IdelPlayerState idleplayerState { get; private set; }
    public MoveStatePlayer moveStatePlayer { get; private set; }
    public AirState airState { get; private set; }
    public JumpState jumpState { get; private set; }
    public DashState dashState { get; private set; }
    public WallSlideState wallSlideState { get; private set; }
    public WallJumpState wallJumpState { get; private set; }
    public PrimaryAttack PrimaryAttack { get; private set; }
	#endregion
	#region components
	public Animator anim {  get; private set; }
    public Rigidbody2D rb { get; private set; }
	#endregion
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
		stateMachine.Initialize(idleplayerState);
       
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.Update();
        CheckForDash();

       
	}

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    private void CheckForDash()
    {
        if (isWallDetected())
        {
            return;
        }

        dashCooldown -= Time.deltaTime;


		if (Input.GetKeyDown(KeyCode.LeftShift) & dashCooldown <=0 )
		{
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
            {
                dashDir = facingDir;
            }
            stateMachine.ChangeState(dashState);
		}
	}
	private void Awake()
	{
		stateMachine = new PlayerStateMachine();
        idleplayerState = new IdelPlayerState(this, stateMachine, "Idle");
        moveStatePlayer = new MoveStatePlayer(this, stateMachine, "Move");
        jumpState = new JumpState(this, stateMachine, "Jump");
        airState = new AirState(this, stateMachine, "Jump");
        dashState = new DashState(this, stateMachine, "Dash");
        wallSlideState = new WallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new WallJumpState(this, stateMachine, "Jump");
        PrimaryAttack = new PrimaryAttack(this, stateMachine, "PrimeAttack");
	}
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipControl(_xVelocity);
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
    public bool isWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance, groundLayer);

	private void OnDrawGizmos()
	{
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance * facingDir, wallCheck.position.y));
	}

	public void Flip()
	{
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
	}

    public void FlipControl(float _xVelocity)
    {
        if (_xVelocity > 0 && !facingRight)
        {
            Flip();
        }
        else if (_xVelocity < 0 && facingRight)
        {
            Flip();
        }
    }
}
