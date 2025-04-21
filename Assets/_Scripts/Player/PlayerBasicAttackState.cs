using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicAttackState : PlayerState
{
    public PlayerBasicAttackState(Player player, PlayerStateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    { }
}
