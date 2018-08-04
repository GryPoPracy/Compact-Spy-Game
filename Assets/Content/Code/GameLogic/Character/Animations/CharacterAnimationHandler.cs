using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{
    [System.Serializable] public class AnimatorParametr
    {
        [SerializeField] private string _name = string.Empty;
        [SerializeField] private int _nameHash = 0;

        private bool _boolValue = false;

        public void SetTrigger(Animator animator)
        {
            animator.SetTrigger(_nameHash);
        }

        public void SetFloat(Animator animator, float value)
        {
            animator.SetFloat(_nameHash, value);
        }

        public void SetBool(Animator animator, bool value)
        {
            if(_boolValue != value)
            {
                _boolValue = value;
                animator.SetBool(_nameHash, value);
            }
        }
    }

    [SerializeField] private AnimatorParametr _run = new AnimatorParametr();
    public AnimatorParametr Run { get { return _run; } }

    [SerializeField] private AnimatorParametr _hack = new AnimatorParametr();
    public AnimatorParametr Hack { get { return _hack; } }
}
