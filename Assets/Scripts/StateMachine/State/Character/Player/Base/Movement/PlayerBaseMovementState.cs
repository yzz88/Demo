using System.Collections;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
/// <summary>
/// 第一个参数是这个状态是属于哪个状态枚举的
/// 第二个参数是这个状态作用于哪个对象
/// </summary>
public class PlayerBaseMovementState : AbstractState<E_PlayerState, CharacterControlbase>
{
    protected CharacterControlbase character;//状态对应的对象
    public PlayerBaseMovementState(FSM<E_PlayerState> fsm, CharacterControlbase target) : base(fsm, target)
    {
        character = target;
    }
    protected override bool OnCondition()
    {
        return character._isGrounded;//想要转到移动状态 必须至少得在地面上
    }
    protected override void OnUpdate()
    {
        
    }
    //这里要在update里检测玩家输入攻击指令
    //写这个移动状态基类的原因就是
    //要统一在update里检测输入攻击指令
    //方便从各个移动状态转换为攻击状态
}
