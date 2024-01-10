using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : AirState
{
	public JumpState(Player _player, PlayerStateMachine _stateMachinge, string _animBoolName) : base(_player, _stateMachinge, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
		rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void Update()
	{
		
        if (rb.velocity.y <= 0 )
        {
			stateMachine.ChangeState(player.airState);
        }
		base.Update();
		GroundCheck();
	}

	protected override void GroundCheck()
	{
		return;
	}
}
