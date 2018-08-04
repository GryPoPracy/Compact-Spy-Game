using UnityEngine;
using ActionsSystem;
using BaseGameLogic.States;
using BaseGameLogic.States.Utility;
using System.Collections;
using System;

public partial class EnterStateAction : BaseAsyncAction
{
    [SerializeField] private StateConstructor stateInfo = new StateConstructor();
    [SerializeField] private ActionList actionList = new ActionList();

    public override IEnumerator Corutine(params object[] data)
    {
        StateHandler handler = SelectObjectForData<StateHandler>(data);
        Type currentStateType = handler.CurrentStateInterfaceHandler.CurrentState.GetType();
        IState newState = stateInfo.GetInstance();
        handler.EnterState(newState);
        string[] typeNamesParts = newState.GetType().ToString().Split('.');
        string stateTypeName = typeNamesParts[typeNamesParts.Length - 1];
        Debug.LogFormat("Object {0} enter {1}.", handler.gameObject.name, stateTypeName);
        yield return new WaitUntil(() => 
        {
            return handler.CurrentStateInterfaceHandler == null || handler.CurrentStateInterfaceHandler.CurrentState.GetType() == currentStateType;
        });
        Debug.LogFormat("Object {0} exit {1}.", handler.gameObject.name, stateTypeName);
    }

    public override void Perform(params object[] data)
    {
        actionList.Perform(data);
    }
}
