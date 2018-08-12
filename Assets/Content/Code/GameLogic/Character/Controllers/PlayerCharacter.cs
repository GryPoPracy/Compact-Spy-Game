using UnityEngine;

using BaseGameLogic.States;
using BaseGameLogic.Singleton;
using BaseGameLogic.States.Providers;

[RequireComponent(typeof(StateHandler), typeof(BaseStateProvider))]
public class PlayerCharacter : SingletonMonoBehaviour<PlayerCharacter>
{
    [SerializeField] private Vector3 _startPosition = Vector3.zero;
    public Vector3 StartPosition
    {
        get { return _startPosition; }
        set { _startPosition = value; }
    }
    [Space]
    [SerializeField] private StateHandler _stateHandler = null;
    [SerializeField] private BaseStateProvider _baseStateProvider = null;


    protected override void Awake()
    {
        base.Awake();
        StartPosition = transform.position;
    }

    public void ClearPlayerState()
    {
        _stateHandler.ClearStack();
    }

    public void ReserToStartPosition()
    {
        transform.position = StartPosition;
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
