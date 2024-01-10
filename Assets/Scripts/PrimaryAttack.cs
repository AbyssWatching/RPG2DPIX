using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : PlayerState
{
	private int comboCounter;
	private float lastTimeAttack;
	private float comboWindow =2;
	public PrimaryAttack(Player _player, PlayerStateMachine _stateMachinge, string _animBoolName) : base(_player, _stateMachinge, _animBoolName)
	{
	}

	public override void Enter()
	{
		base.Enter();
		Debug.Log("Combo count " + comboCounter);
        if (comboCounter > 2)
        {
			comboCounter = 0;
        }

    }

	public override void Exit()
	{
		base.Exit();
		comboCounter++;
		lastTimeAttack = Time.time;
		Debug.Log(lastTimeAttack);

	}

	public override void Update()
	{
		base.Update();

		if (triggerCalled)
		{
			stateMachine.ChangeState(player.idleplayerState);
		}
	}
}
