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
        FSM.AddState(E_PlayerState.WalkStop, new PlayerWalkStopState(FSM, this));
        FSM.AddState(E_PlayerState.RunStop, new PlayerRunStopState(FSM, this));
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
    /// 还需解决 玩家的面朝方向随着镜头的变化而变化
    /// </summary>
    private void Rotate()
    {
        // 获取摄像机的旋转角度
        float cameraYRotation = Camera.main.transform.eulerAngles.y;

        // 获取玩家输入的方向
        Vector3 inputDirection = new Vector3(GameInputManager.MainInstance._moveDirection.x, 0, GameInputManager.MainInstance._moveDirection.y);
        if (inputDirection == Vector3.zero) return;

        // 将输入方向转换为相对于摄像机的方向
        Quaternion cameraRotation = Quaternion.Euler(0, cameraYRotation, 0);
        Vector3 relativeInputDirection = cameraRotation * inputDirection;

        // 计算目标旋转角度
        Quaternion targetRotation = Quaternion.LookRotation(relativeInputDirection);

        // 平滑旋转
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSmooth * Time.deltaTime);
    }
}
