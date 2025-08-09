using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class PlayerRunState : PlayerBaseMovementState
{
    public PlayerRunState(FSM<E_PlayerState> fsm, CharacterControlbase target) : base(fsm, target)
    {
    }
    protected override bool OnCondition()
    {
        return base.OnCondition();
    }
    protected override void OnEnter()
    {
        Debug.Log("进入run状态");
        character._animator.CrossFadeInFixedTime("Run", 0.1555f, 0, 0f);
    }

    protected override void OnUpdate()
    {
        if (!GameInputManager.MainInstance._RunIsTriggered)
        {
            mFSM.ChangeState(E_PlayerState.Walk);
        }
        //如果在奔跑状态下 wasd没有按 就进入奔跑停止
        if (!GameInputManager.MainInstance._hasMovementInput)
        {
            mFSM.ChangeState(E_PlayerState.RunStop);
        }
    }
    protected override void OnExit()
    {
        Debug.Log("退出run状态");
    }
}
