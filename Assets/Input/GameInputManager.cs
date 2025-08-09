using Demo.Tool.Singleton;
using UnityEngine;

public class GameInputManager : SingletonMono<GameInputManager>
{
    private PlayerInputActions _playerInputAction;

    public Vector2 _moveDirection;//move�ķ���

    public bool _hasMovementInput;//wasd�Ƿ�������

    public bool _RunIsTriggered;//���ܼ��Ƿ��������
    public PlayerInputActions.PlayerActions playerActions{ get; private set; }
    protected override void Awake()
    {
        base.Awake();
        _playerInputAction ??= new PlayerInputActions();
        playerActions = _playerInputAction.Player;
    }

    private void Update()
    {
        _hasMovementInput = playerActions.Move.ReadValue<Vector2>() != Vector2.zero;
        _RunIsTriggered = playerActions.Run.IsPressed();
        _moveDirection = playerActions.Move.ReadValue<Vector2>().normalized;
    }
    private void OnEnable()
    {
        _playerInputAction.Enable();
    }

    private void OnDisable()
    {
        _playerInputAction.Disable();
    }
}
