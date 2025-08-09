using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class PlayerIdleState : PlayerBaseMovementState
{
    public PlayerIdleState(FSM<E_PlayerState> fsm, CharacterControlbase target) : base(fsm, target)
    {
    }

    protected override void OnUpdate()
    {
        if(GameInputManager.MainInstance._hasMovementInput)
        {
            if(GameInputManager.MainInstance._RunIsTriggered)
            {
                mFSM.ChangeState(E_PlayerState.Run);
            }
            else
            {
                mFSM.ChangeState(E_PlayerState.Walk);
            }
        }
    }
    protected override bool OnCondition()
    {
        return base.OnCondition();
    }
    protected override void OnEnter()
    {
        Debug.Log("½øÈëidle×´Ì¬");
        character._animator.CrossFadeInFixedTime("Idle", 0.1555f, 0, 0f);
    }

    protected override void OnExit()
    {
        Debug.Log("ÍË³öidle×´Ì¬");
    }
}
