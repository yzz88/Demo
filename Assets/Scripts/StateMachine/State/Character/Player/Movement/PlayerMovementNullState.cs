using QFramework;
/// <summary>
/// �����ƶ��Ŀ�״̬
/// ��ֹ��ս��״̬��ս����ͻ
/// </summary>
public class PlayerMovementNullState : PlayerBaseMovementState
{
    public PlayerMovementNullState(FSM<E_PlayerState> fsm, CharacterControlbase target) : base(fsm, target)
    {
    }

    protected override void OnEnter()
    {
        
    }

    protected override void OnExit()
    {
        
    }
}
