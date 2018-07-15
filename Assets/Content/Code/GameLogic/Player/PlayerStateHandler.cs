using BaseGameLogic.States;
using BaseGameLogic.States.Providers;
using Player.States;

namespace Player
{
    public class PlayerStateHandler : BaseStateProvider
    {
        public override IState DefaultState { get { return new LocomotionState(); } }
    }
}
