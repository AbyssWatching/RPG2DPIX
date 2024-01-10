using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpState : PlayerState
{
	public WallJumpState(Player _player, PlayerStateMachine _stateMachinge, string _animBoolName) : base(_player, _stateMachinge, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
		stateTimer = .4f;
		player.SetVelocity(player.wallJumpForce * -player.facingDir, player.jumpForce);
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		base.Update();
		if (stateTimer < 0)
		{
			stateMachine.ChangeState(player.airState);
		}
	}


}
