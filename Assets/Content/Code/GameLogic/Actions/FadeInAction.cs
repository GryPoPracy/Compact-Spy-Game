using ActionsSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAction : BaseAsyncAction
{
    public override IEnumerator Corutine(params object[] data)
    {
        CaughtCanvas.Instance.FadeIn();

        yield return new WaitUntil(() => { return CaughtCanvas.Instance.FadedIn; });

        //yield return new WaitUntil(()=> { return !Input.anyKeyDown; });
    }
}
