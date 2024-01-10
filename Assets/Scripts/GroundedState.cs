using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
	public GroundedState(Player _player, PlayerStateMachine _stateMachinge, string _animBoolName) : base(_player, _stateMachinge, _animBoolName)
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

		if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected())
		{
			stateMachine.ChangeState(player.jumpState);
			return;
		}
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
			stateMachine.ChangeState(player.PrimaryAttack);
        }

        if (!player.IsGroundDetected())
		{
			stateMachine.ChangeState(player.airState);
		}
	

	}
}
