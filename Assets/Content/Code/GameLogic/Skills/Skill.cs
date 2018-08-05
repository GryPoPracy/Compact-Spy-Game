using ActionsSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Skills
{
    public class Skill : MonoBehaviour
    {
        [SerializeField] private float _countDownTime = 1f;
        private float _countDownCounter = 0;
        [SerializeField] private ActionList _useSkillActionList = new ActionList();
        [SerializeField] private ActionList _restoreSkillActionList = new ActionList();

        public CountdownCallback CountdownCallback = new CountdownCallback();

        public void Perform()
        {
            if (_countDownCounter > 0)
                return;

            _useSkillActionList.Perform();
            StartCoroutine(CountdownCorutine());
        }

        private IEnumerator CountdownCorutine()
        {
            _countDownCounter = _countDownTime;

            while (_countDownCounter > 0)
            {
                _countDownCounter -= Time.deltaTime;
                CountdownCallback.Invoke(1 - (_countDownCounter / _countDownTime));
                yield return null;
            }

            _restoreSkillActionList.Perform();
        }
    }

    [Serializable] public class CountdownCallback : UnityEvent<float> {}
}
