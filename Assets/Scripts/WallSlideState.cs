using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideState : PlayerState
{
	public WallSlideState(Player _player, PlayerStateMachine _stateMachinge, string _animBoolName) : base(_player, _stateMachinge, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();

		if (Input.GetKeyDown(KeyCode.Space))
		{
			stateMachine.ChangeState(player.wallJumpState);
			return;
		}
		
		if (yInput < 0)
        {
			player.SetVelocity(0, rb.velocity.y);
		}
        else
        {
			player.SetVelocity(0, rb.velocity.y * .5f);
		}

		if (player.IsGroundDetected()) 
        {
			stateMachine.ChangeState(player.idleplayerState);
        }
        
		if (xInput != 0 && player.facingDir != xInput )
        {
			stateMachine.ChangeState(player.idleplayerState);
        }
    }

}
