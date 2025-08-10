using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComboData",menuName = "ScriptObject/Combo/ComboData")]
public class CombatData : ScriptableObject
{
    #region 基础数据
    //因为一个招式里可能不止一段攻击 所以有些数据可能要写成数组
    [Header("招式对应的动画名称")] public string comboName;
    [Header("招式的伤害")] public float[] _damage;
    [Header("招式的冷却时间")] public float coldTime;
    [Header("招式对应的受击信息")] public ComboInteractionConfig[] interactionConfig;
    [Header("招式对应的攻击检测信息")] public ComboDetectionConfig[] detectionConfig;
    [Header("该招式对应的特效")]public VFXConfig[] vfx;
    [Header("该招式对应的音效")]public SFXConfig[] sfx;
    #endregion
}
[Serializable]
public class ComboInteractionConfig
{
    [Header("对应的受击动画名称")]public string[] hitName;
    [Header("对应的空中受击动画名称")]public string[] air_HitName;
}
[Serializable]
public class ComboDetectionConfig
{
    [Header("攻击检测开始时间")] public float startTime;
    [Header("攻击检测的位置")] public Vector3 position;
    [Header("攻击检测的旋转")] public Vector3 rotation;
    [Header("攻击检测的缩放")] public Vector3 scale;
}
[Serializable]
public class VFXConfig
{
    [Header("特效名字")]public string vfxName;
    [Header("特效生成的位置")]public Vector3 position;
    [Header("特效生成的位置")] public Vector3 rotation;
    [Header("特效生成的位置")] public Vector3 scale;
    [Header("特效的持续时间")] public float duration;
}
[Serializable]
public class SFXConfig
{
    [Header("音效名字")] public string sfxName;
    [Header("音效音量的大小")] public float volume;
    [Header("特效的持续时间")] public float duration;
}
