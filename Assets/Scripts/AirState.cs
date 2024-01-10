using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : PlayerState
{
	public AirState(Player _player, PlayerStateMachine _stateMachinge, string _animBoolName) : base(_player, _stateMachinge, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		player.SetVelocity(0,0);
		base.Exit();	
	}

	public override void Update()
	{
		base.Update();
      
		if (player.isWallDetected()) 
		{
			stateMachine.ChangeState(player.wallSlideState);
		}
		if (xInput != 0 )
		{
			player.SetVelocity(player.moveSpeed * player.AirMovementPenealty * xInput, rb.velocity.y);
		}
		
		GroundCheck();
	}

	protected virtual void GroundCheck()
	{
		if (player.IsGroundDetected())
		{
			stateMachine.ChangeState(player.idleplayerState);
		}
	}
}
