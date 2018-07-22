using UnityEngine;

using BaseGameLogic.States;
using BaseGameLogic.Singleton;
using BaseGameLogic.States.Providers;

[RequireComponent(typeof(StateHandler), typeof(BaseStateProvider))]
public class PlayerCharacter : Singleton<PlayerCharacter>
{
    [SerializeField] private Vector3 _startPosition = Vector3.zero;
    [Space]
    [SerializeField] private StateHandler _stateHandler = null;
    [SerializeField] private BaseStateProvider _baseStateProvider = null;

    protected override void Awake()
    {
        base.Awake();
        _startPosition = transform.position;
    }

    public void ClearPlayerState()
    {
        _stateHandler.ClearStack();
    }

    public void ReserToStartPosition()
    {
        transform.position = _startPosition;
    }

    public void EnterDefaultState()
    {
        _baseStateProvider.EnterDefaultState();
    }

    private void Reset()
    {
        _stateHandler = GetComponent<StateHandler>();
        _baseStateProvider = GetComponent<BaseStateProvider>();
    }
}
