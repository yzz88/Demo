using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ComboData",menuName = "ScriptObject/Combo/ComboData")]
public class CombatData : ScriptableObject
{
    #region ��������
    //��Ϊһ����ʽ����ܲ�ֹһ�ι��� ������Щ���ݿ���Ҫд������
    [Header("��ʽ��Ӧ�Ķ�������")] public string comboName;
    [Header("��ʽ���˺�")] public float[] _damage;
    [Header("��ʽ����ȴʱ��")] public float coldTime;
    [Header("��ʽ��Ӧ���ܻ���Ϣ")] public ComboInteractionConfig[] interactionConfig;
    [Header("��ʽ��Ӧ�Ĺ��������Ϣ")] public ComboDetectionConfig[] detectionConfig;
    [Header("����ʽ��Ӧ����Ч")]public VFXConfig[] vfx;
    [Header("����ʽ��Ӧ����Ч")]public SFXConfig[] sfx;
    #endregion
}
[Serializable]
public class ComboInteractionConfig
{
    [Header("��Ӧ���ܻ���������")]public string[] hitName;
    [Header("��Ӧ�Ŀ����ܻ���������")]public string[] air_HitName;
}
[Serializable]
public class ComboDetectionConfig
{
    [Header("������⿪ʼʱ��")] public float startTime;
    [Header("��������λ��")] public Vector3 position;
    [Header("����������ת")] public Vector3 rotation;
    [Header("������������")] public Vector3 scale;
}
[Serializable]
public class VFXConfig
{
    [Header("��Ч����")]public string vfxName;
    [Header("��Ч���ɵ�λ��")]public Vector3 position;
    [Header("��Ч���ɵ�λ��")] public Vector3 rotation;
    [Header("��Ч���ɵ�λ��")] public Vector3 scale;
    [Header("��Ч�ĳ���ʱ��")] public float duration;
}
[Serializable]
public class SFXConfig
{
    [Header("��Ч����")] public string sfxName;
    [Header("��Ч�����Ĵ�С")] public float volume;
    [Header("��Ч�ĳ���ʱ��")] public float duration;
}
