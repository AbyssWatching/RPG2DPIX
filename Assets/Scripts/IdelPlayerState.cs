using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelPlayerState : GroundedState
{
    public IdelPlayerState(Player _player, PlayerStateMachine _stateMache, string _animBoolName) : base(_player, _stateMache, _animBoolName)
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

		if (xInput == player.facingDir && player.isWallDetected())
		{
			return;
		}

		
		if (xInput != 0)
		{
			stateMachine.ChangeState(player.moveStatePlayer);
		}
	}
 
}
