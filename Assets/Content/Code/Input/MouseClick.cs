using UnityEngine;
using UnityEngine.EventSystems;

namespace BaseGameLogic.Inputs.Screen
{
    public class MouseClick : ScreenClick
    {
        public override bool IsPositive { get { return Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(); } }
        public override Vector3 ScrennPosition { get { return Input.mousePosition; } }
    }
}