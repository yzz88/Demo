using System.Collections;
using System.Collections.Generic;
using QFramework;
using Unity.Mathematics;
using UnityEngine;

public class PlayerControl : CharacterControlbase
{
    FSM<E_PlayerState> FSM;
    [SerializeField,Header("旋转平滑度")] private float rotateSmooth;
    protected override void Awake()
    {
        base.Awake();
        FSM = new FSM<E_PlayerState>();
        FSM.AddState(E_PlayerState.Idle, new PlayerIdleState(FSM, this));
        FSM.AddState(E_PlayerState.Walk, new PlayerWalkState(FSM, this));
        FSM.AddState(E_PlayerState.Run, new PlayerRunState(FSM, this));
        FSM.StartState(E_PlayerState.Idle);
    }
    protected override void OnAnimatorMove()
    {
        base.OnAnimatorMove();
    }
    protected override void Update()
    {
        base.Update();
        FSM.Update();
        Rotate();
    }
    /// <summary>
    /// 玩家旋转的方法
    /// </summary>
    private void Rotate()
    {
        Vector3 inputDiretion = new Vector3(GameInputManager.MainInstance._moveDirection.x, 0, GameInputManager.MainInstance._moveDirection.y);
        if (inputDiretion == Vector3.zero) return;
        Quaternion targetAngle = Quaternion.LookRotation(inputDiretion);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, rotateSmooth*Time.deltaTime);
    }
}
