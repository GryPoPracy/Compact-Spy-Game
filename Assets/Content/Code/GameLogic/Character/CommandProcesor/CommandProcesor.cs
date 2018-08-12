using BaseGameLogic.Inputs.Screen;
using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public partial class CommandProcesor : SingletonMonoBehaviour<CommandProcesor>, ISupervisor
    {
        public enum CommadStering { Player, Skill }

        public CommadStering Stering = CommadStering.Player;

        private Command _playerCommand = null;
        private Command _skillCommad = null;

        public Command CurrenntCommand { get { return _playerCommand; } }

        protected override void Start()
        {
            base.Start();
            if (ScreenInput.Instance != null)
            {
                ScreenInput.Instance.ObjectSelectedCallback.AddListener(Process);
                ScreenInput.Instance.ObjectSelected2DCallback.AddListener(Process);
            }
        }

        private void Process(ClickInfo2D arg0)
        {
            switch (Stering)
            {
                case CommadStering.Player:
                    _playerCommand = new Command(arg0.WorldPosition, Vector3.zero, arg0.GameObject);
                    break;
                case CommadStering.Skill:
                    _skillCommad = new Command(arg0.WorldPosition, Vector3.zero, arg0.GameObject);
                    break;
            }
        }

        private void Process(ClickInfo arg1)
        {
            _playerCommand = new Command(arg1.WorldPosition, arg1.GameObject);
        }

        public void Consume()
        {
            _playerCommand = null;
        }
    }
}