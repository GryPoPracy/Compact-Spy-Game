using UnityEngine;

namespace BaseGameLogic.Inputs.Screen
{
    public class MouseClick : ScreenClick
    {
        public override bool IsPositive { get { return Input.GetMouseButtonDown(0); } }
        public override Vector3 ScrennPosition { get { return Input.mousePosition; } }
    }
}