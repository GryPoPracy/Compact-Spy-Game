using ActionsSystem;
using BaseGameLogic.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventsManager : Singleton<GlobalEventsManager>
{
    [SerializeField] private ActionList _playerDetectedActions = new ActionList();
    
    public void PlayerDetected()
    {
        _playerDetectedActions.Perform();
    }
}
