using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainGameLogic.Action
{
    public class FadeOutAction : BaseAsyncAction
    {
        public override IEnumerator Corutine(params object[] data)
        {
            CaughtCanvas.Instance.FadeOut();
            yield return new WaitUntil(() => { return CaughtCanvas.Instance.FadedOut; });
        }
    }
}