using UnityEngine;
using UnityEngine.EventSystems;

namespace BaseGameLogic.Inputs.Screen
{
    public class MouseClick : ScreenClick
    {
        private enum MouseButton
        {
            Left = 0,
            Middle = 1,
            Right = 2
        }

        [SerializeField] private MouseButton _mouseButton = MouseButton.Left;

        public override bool IsPositive { get { return Input.GetMouseButtonDown((int)_mouseButton) && !EventSystem.current.IsPointerOverGameObject(); } }
        public override Vector3 ScrennPosition { get { return Input.mousePosition; } }
    }
}