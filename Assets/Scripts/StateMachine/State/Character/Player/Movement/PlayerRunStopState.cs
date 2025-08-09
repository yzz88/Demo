using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class PlayerRunStopState : PlayerBaseMovementState
{
    public PlayerRunStopState(FSM<E_PlayerState> fsm, CharacterControlbase target) : base(fsm, target)
    {
    }

    protected override bool OnCondition()
    {
        //ֻ�е�ǰ״̬�Ǳ��ܲſ��ܽ��뱼��ֹͣ
        return mFSM.CurrentStateId == E_PlayerState.Run;
    }
    protected override void OnEnter()
    {
        Debug.Log("���뱼��ֹͣ");
        character._animator.CrossFadeInFixedTime("RunStop", 0.1555f, 0, 0);
    }
    protected override void OnUpdate()
    {
        if (character._animator.GetCurrentAnimatorStateInfo(0).IsName("RunStop"))
        {
            if (character._animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
            {
                mFSM.ChangeState(E_PlayerState.Idle);
            }
        }
        
    }
}
