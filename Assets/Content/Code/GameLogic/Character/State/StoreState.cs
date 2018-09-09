using BaseGameLogic.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreState : IState, IOnUpdate
{
    [RequiredReference] private StateHandler _stateHandler = null;

    public void OnEnter()
    {
        StoreCanvas.Instance.gameObject.SetActive(true);
    }

    public void OnExit() {}

    public void OnUpdate()
    {
        if (!StoreCanvas.Instance.gameObject.activeSelf)
            _stateHandler.ExitState();
    }
}
