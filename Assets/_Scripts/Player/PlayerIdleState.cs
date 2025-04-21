using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _stateMachine.ChangeState(_player.MoveState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
