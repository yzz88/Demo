using System.Collections;
using System.Collections.Generic;
using QFramework;
using Unity.Mathematics;
using UnityEngine;

public class PlayerControl : CharacterControlbase
{
    FSM<E_PlayerState> FSM;
    [SerializeField,Header("��תƽ����")] private float rotateSmooth;
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
    /// �����ת�ķ���
    /// ������ ��ҵ��泯�������ž�ͷ�ı仯���仯
    /// </summary>
    private void Rotate()
    {
        // ��ȡ���������ת�Ƕ�
        float cameraYRotation = Camera.main.transform.eulerAngles.y;

        // ��ȡ�������ķ���
        Vector3 inputDirection = new Vector3(GameInputManager.MainInstance._moveDirection.x, 0, GameInputManager.MainInstance._moveDirection.y);
        if (inputDirection == Vector3.zero) return;

        // �����뷽��ת��Ϊ�����������ķ���
        Quaternion cameraRotation = Quaternion.Euler(0, cameraYRotation, 0);
        Vector3 relativeInputDirection = cameraRotation * inputDirection;

        // ����Ŀ����ת�Ƕ�
        Quaternion targetRotation = Quaternion.LookRotation(relativeInputDirection);

        // ƽ����ת
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotateSmooth * Time.deltaTime);
    }
}
