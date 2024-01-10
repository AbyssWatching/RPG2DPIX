using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
	public DashState(Player _player, PlayerStateMachine _stateMachinge, string _animBoolName) : base(_player, _stateMachinge, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
		stateTimer = player.dashDuration; ;
	}

	public override void Exit()
	{
		

		base.Exit();
		player.SetVelocity(0, rb.velocity.y);
	}

	public override void Update()
	{
		base.Update();

		player.SetVelocity(player.dashSpeed * player.dashDir, 0);

		if (stateTimer < 0) 
		{
			stateMachine.ChangeState(player.idleplayerState);
		}

		if (!player.IsGroundDetected() && player.isWallDetected())
		{
			stateMachine.ChangeState(player.wallSlideState);
		}
		
	}


}
