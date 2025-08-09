using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerWalkStopState : PlayerBaseMovementState
{
    public PlayerWalkStopState(FSM<E_PlayerState> fsm, CharacterControlbase target) : base(fsm, target)
    {
    }

    protected override bool OnCondition()
    {
        //只有当前状态是奔跑才可能进入奔跑停止
        return mFSM.CurrentStateId == E_PlayerState.Walk;
    }
    protected override void OnEnter()
    {
        Debug.Log("进入行走停止");
        character._animator.CrossFadeInFixedTime("WalkStop", 0.1555f, 0, 0);
    }

    protected override void OnUpdate()
    {
        if (character._animator.GetCurrentAnimatorStateInfo(0).IsName("WalkStop"))
        {
            if (character._animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
            {
                mFSM.ChangeState(E_PlayerState.Idle);
            }
        }
        
    }
}
