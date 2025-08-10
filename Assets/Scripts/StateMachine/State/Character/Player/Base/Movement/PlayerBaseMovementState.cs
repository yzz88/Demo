
using QFramework;
/// <summary>
/// ��һ�����������״̬�������ĸ�״̬ö�ٵ�
/// �ڶ������������״̬�������ĸ�����
/// </summary>
public class PlayerBaseMovementState : AbstractState<E_PlayerState, CharacterControlbase>
{
    protected CharacterControlbase character;//״̬��Ӧ�Ķ���
    public PlayerBaseMovementState(FSM<E_PlayerState> fsm, CharacterControlbase target) : base(fsm, target)
    {
        character = target;
    }
    protected override bool OnCondition()
    {
        return character._isGrounded;//��Ҫת���ƶ�״̬ �������ٵ��ڵ�����
    }
    protected override void OnUpdate()
    {
        if(GameInputManager.MainInstance._LAttackTriggered)
        {
            mFSM.ChangeState(E_PlayerState.Null);
        }
        if(mFSM.CurrentStateId == E_PlayerState.Null)
        {
            if (GameInputManager.MainInstance._hasMovementInput)
            {
                mFSM.ChangeState(E_PlayerState.Walk);
            }
            
        }
    }
    //����Ҫ��update����������빥��ָ��
    //д����ƶ�״̬�����ԭ�����
    //Ҫͳһ��update�������빥��ָ��
    //����Ӹ����ƶ�״̬ת��Ϊ����״̬
}
