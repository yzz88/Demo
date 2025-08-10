using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PlayerState 
{
    Idle,//待机
    Walk,//行走
    Run,//奔跑
    WalkStop,//行走停止
    RunStop,//奔跑停止
    Null//空状态
}
public enum E_PlayerCombat
{
    normalCombo1,//第一段普通攻击
    normalCombo2,//第二段普通攻击
    normalCombo3,//第三段普通攻击
    normalCombo4,//第四段普通攻击
    Null//空状态
}
