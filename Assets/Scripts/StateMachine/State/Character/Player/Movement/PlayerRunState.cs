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
        Debug.Log("����run״̬");
        character._animator.CrossFadeInFixedTime("Run", 0.1555f, 0, 0f);
    }

    protected override void OnUpdate()
    {
        if (!GameInputManager.MainInstance._RunIsTriggered)
        {
            mFSM.ChangeState(E_PlayerState.Walk);
        }
        //����ڱ���״̬�� wasdû�а� �ͽ��뱼��ֹͣ
        if (!GameInputManager.MainInstance._hasMovementInput)
        {
            mFSM.ChangeState(E_PlayerState.RunStop);
        }
    }
    protected override void OnExit()
    {
        Debug.Log("�˳�run״̬");
    }
}
