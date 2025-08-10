using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(CharacterController))]
public class CharacterControlbase : MonoBehaviour
{
    #region 角色组件获取
    public Animator _animator;//角色动画组件
    private CharacterController _cc;//角色控制器
    #endregion
    #region 声明变量
    public List<CombatData> comboDataList;//连招表
    [SerializeField,Header("移动速度")] private float _moveSpeed;
    [SerializeField, Header("地面检测层级")] private LayerMask _detectionMask;
    [SerializeField, Header("球形检测的最远距离")] private float _detectionMaxDistance;
    [SerializeField, Header("重力加速度")] private float _gravityMutiple;
    [SerializeField, Header("角色地面检测的物体")] GameObject _detectionObj;
    private float _sphereRadius = 0.15f;
    private float _gravity = -9.81f;//默认重力
    private float _verticalSpeed;//垂直的速度
    [SerializeField]public bool _isGrounded;//是否在地面上
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
    /// 角色的位移
    /// 在OnAnimatorMove中实现
    /// </summary>
    protected virtual void OnAnimatorMove()
    {
        Vector3 horizontalMove = _animator.deltaPosition * _moveSpeed;
        _cc.Move(new Vector3(horizontalMove.x, _verticalSpeed, horizontalMove.z));
    }
    /// <summary>
    /// 检测是否在地面
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
    /// 更新重力逻辑
    /// 分为在地面与不在地面两种逻辑
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
    /// 尝试获取一个招式
    /// </summary>
    public CombatData TryGetOneCombatData(string comboName)
    {
        //如果招式表中的某个招式名字与传进来的招式名字一样则返回该具体招式
        foreach (CombatData combat in comboDataList)
        {
            if (combat.comboName == comboName)
            {
                return combat;
            }
        }
        Debug.Log("未找到相关数据");
        return null;
    }

}
