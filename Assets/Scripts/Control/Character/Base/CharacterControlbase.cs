using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(CharacterController))]
public class CharacterControlbase : MonoBehaviour
{
    #region ��ɫ�����ȡ
    public Animator _animator;//��ɫ�������
    private CharacterController _cc;//��ɫ������
    #endregion
    #region ��������
    public List<CombatData> comboDataList;//���б�
    [SerializeField,Header("�ƶ��ٶ�")] private float _moveSpeed;
    [SerializeField, Header("������㼶")] private LayerMask _detectionMask;
    [SerializeField, Header("���μ�����Զ����")] private float _detectionMaxDistance;
    [SerializeField, Header("�������ٶ�")] private float _gravityMutiple;
    [SerializeField, Header("��ɫ�����������")] GameObject _detectionObj;
    private float _sphereRadius = 0.15f;
    private float _gravity = -9.81f;//Ĭ������
    private float _verticalSpeed;//��ֱ���ٶ�
    [SerializeField]public bool _isGrounded;//�Ƿ��ڵ�����
    #endregion
    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        _cc = GetComponent<CharacterController>();
    }
    protected virtual void Update()
    {
        CheckGrounded();
        UpdateGravity();
    }
    /// <summary>
    /// ��ɫ��λ��
    /// ��OnAnimatorMove��ʵ��
    /// </summary>
    protected virtual void OnAnimatorMove()
    {
        Vector3 horizontalMove = _animator.deltaPosition * _moveSpeed;
        _cc.Move(new Vector3(horizontalMove.x, _verticalSpeed, horizontalMove.z));
    }
    /// <summary>
    /// ����Ƿ��ڵ���
    /// </summary>
    protected virtual void CheckGrounded()
    {
        if(Physics.SphereCast(_detectionObj.transform.position, _sphereRadius,
            Vector3.down, out var hit, _detectionMaxDistance, _detectionMask, QueryTriggerInteraction.Ignore))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        
    }
    /// <summary>
    /// ���������߼�
    /// ��Ϊ�ڵ����벻�ڵ��������߼�
    /// </summary>
    protected virtual void UpdateGravity()
    {
        if(_isGrounded)
        {
            _verticalSpeed = -2f;
        }
        else
        {
            _verticalSpeed += _gravity * _gravityMutiple * Time.deltaTime;
        }
        
        
    }

    /// <summary>
    /// ���Ի�ȡһ����ʽ
    /// </summary>
    public CombatData TryGetOneCombatData(string comboName)
    {
        //�����ʽ���е�ĳ����ʽ�����봫��������ʽ����һ���򷵻ظþ�����ʽ
        foreach (CombatData combat in comboDataList)
        {
            if (combat.comboName == comboName)
            {
                return combat;
            }
        }
        Debug.Log("δ�ҵ��������");
        return null;
    }

}
