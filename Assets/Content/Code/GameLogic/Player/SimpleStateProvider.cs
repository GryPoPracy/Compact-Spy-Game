using BaseGameLogic.States;
using BaseGameLogic.States.Providers;
using BaseGameLogic.States.Utility;
using Player.States;
using UnityEngine;

namespace Player
{
    public class SimpleStateProvider : BaseStateProvider
    {
        [SerializeField] private StateConstructor _defaultState = new StateConstructor();
        public override IState DefaultState { get { return _defaultState.GetInstance(); } }
    }
}
