using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrowState : PlayerState
{
    public PlayerThrowState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    { }
}
