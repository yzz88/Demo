using UnityEngine;

[RequireComponent(typeof(Animator),typeof(CharacterController))]
public class CharacterControlbase : MonoBehaviour
{
    #region ��ɫ�����ȡ
    public Animator _animator;//��ɫ�������
    private CharacterController _cc;//��ɫ������
    #endregion
    #region ��������
    [SerializeField,Header("�ƶ��ٶ�")] private float _moveSpeed;
    [SerializeField, Header("������㼶")] private LayerMask _detectionMask;
    [SerializeField, Header("���μ�����Զ����")] private float _detectionMaxDistance;
    [SerializeField, Header("�������ٶ�")] private float _gravityMutiple;
    [SerializeField, Header("��ɫ�����������")] GameObject _detectionObj;
    private float _sphereRadius = 0.15f;
    private float _gravity = -9.81f;//Ĭ������
    private float _verticalSpeed;//��ֱ���ٶ�
    [SerializeField]private bool _isGrounded;//�Ƿ��ڵ�����
    private Vector3 _verticalDirection;//�ƶ�����(��ֱ)
    #endregion
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        CheckGrounded();
        UpdateGravity();
    }
    /// <summary>
    /// ��ɫ��λ��
    /// ��OnAnimatorMove��ʵ��
    /// </summary>
    private void OnAnimatorMove()
    {
        _cc.Move(_animator.deltaPosition * _moveSpeed * Time.deltaTime);
    }
    /// <summary>
    /// ����Ƿ��ڵ���
    /// </summary>
    private void CheckGrounded()
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
    private void UpdateGravity()
    {
        if(_isGrounded)
        {
            _verticalSpeed = -2f;
        }
        else
        {
            _verticalSpeed += _gravity * _gravityMutiple * Time.deltaTime;
        }
        
        _cc.Move(new Vector3(0f,_verticalSpeed * Time.deltaTime,0f));
    }

}
