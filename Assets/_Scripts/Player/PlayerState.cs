using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player _player;
    protected PlayerStateMachine _stateMachine;
    private readonly string _stateName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string stateName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _stateName = stateName;
    }

    public virtual void Enter()
    {
        Debug.Log($"Entering {_stateName} state");
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        Debug.Log($"Exiting {_stateName} state");
    }
}
