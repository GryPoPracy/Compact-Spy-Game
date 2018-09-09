using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCanvas : SingletonMonoBehaviour<StoreCanvas>
{
    protected override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
    }
}
