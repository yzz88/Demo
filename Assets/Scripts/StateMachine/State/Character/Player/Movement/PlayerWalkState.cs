using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class PlayerWalkState : PlayerBaseMovementState
{
    public PlayerWalkState(FSM<E_PlayerState> fsm, CharacterControlbase target) : base(fsm, target)
    {
    }
    protected override bool OnCondition()
    {
        return base.OnCondition();
    }
    protected override void OnEnter()
    {
        Debug.Log("½øÈëwalk×´Ì¬");
        character._animator.CrossFadeInFixedTime("Walk", 0.1555f, 0, 0f);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (!GameInputManager.MainInstance._hasMovementInput)
        {
            mFSM.ChangeState(E_PlayerState.Idle);
        }
        if (GameInputManager.MainInstance._RunIsTriggered)
        {
            mFSM.ChangeState(E_PlayerState.Run);
        }
    }
    protected override void OnExit()
    {
        Debug.Log("ÍË³öwalk×´Ì¬");
    }
}
