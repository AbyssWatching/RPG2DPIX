using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
	protected PlayerStateMachine stateMachine;
	protected Player player;

	private string animBoolName;
	protected float xInput;
	protected float yInput;
	protected bool triggerCalled;
	protected Rigidbody2D rb;

	protected float stateTimer;
	public PlayerState(Player _player, PlayerStateMachine _stateMachinge, string _animBoolName)
	{
		this.player = _player;
		this.stateMachine = _stateMachinge;
		this.animBoolName = _animBoolName;

	}

	public virtual void Enter()
	{
		Debug.Log("I'm in " + stateMachine.currentState);
		player.anim.SetBool(animBoolName, true);
		rb = player.rb;
		triggerCalled = false;
	}

	public virtual void Exit()
	{
		player.anim.SetBool(animBoolName, false);
	}

	public virtual void Update()
	{
		yInput = Input.GetAxisRaw("Vertical");
		xInput = Input.GetAxisRaw("Horizontal");
		stateTimer -= Time.deltaTime; 
		
	}
	public virtual void AnimationFinishTrigger()
	{
		triggerCalled = true;
	}
}
