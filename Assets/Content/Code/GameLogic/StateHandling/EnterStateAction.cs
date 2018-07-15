using UnityEngine;
using ActionsSystem;
using BaseGameLogic.States;
using BaseGameLogic.States.Utility;

public partial class EnterStateAction : BaseAction
{
    [SerializeField] private StateInfo stateInfo = new StateInfo();

    public override void Perform(params object[] list)
    {
        StateHandler handler = SelectObjectForData<StateHandler>(list);
        handler.EnterState(stateInfo.GetInstance());
    }
}
