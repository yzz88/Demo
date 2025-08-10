using QFramework;
/// <summary>
/// 这是移动的空状态
/// 防止与战斗状态机战斗冲突
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
