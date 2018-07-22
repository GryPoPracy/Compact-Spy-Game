using UnityEngine;
using ActionsSystem;
using BaseGameLogic.States;
using BaseGameLogic.States.Utility;

public partial class EnterStateAction : BaseAction
{
    [SerializeField] private StateConstructor stateInfo = new StateConstructor();

    public override void Perform(params object[] list)
    {
        StateHandler handler = SelectObjectForData<StateHandler>(list);
        handler.EnterState(stateInfo.GetInstance());
    }
}
