using ActionsSystem;
using BaseGameLogic.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventsManager : Singleton<GlobalEventsManager>
{
    [SerializeField] private List<GlobalEvent> _eventList = new List<GlobalEvent>();
    public List<GlobalEvent> EventList { get { return _eventList; } }
    private Dictionary<string, GlobalEvent> _eventsDictionary = new Dictionary<string, GlobalEvent>();

    protected override void Awake()
    {
        base.Awake();
        foreach (var item in _eventList)
            _eventsDictionary.Add(item.Name, item);
    }

    [Serializable] public class GlobalEvent
    {
        [SerializeField] private string _name = string.Empty;
        public string Name { get { return _name; } }

        [SerializeField] private ActionList _eventActions = new ActionList();

        public void ActivateEvent(params object[] data)
        {
            _eventActions.Perform(data);
        }
    }

    public void TriggerEvent(string name, params object[] data)
    {
        GlobalEvent @event = null;
        if (_eventsDictionary.TryGetValue(name, out @event))
            @event.ActivateEvent(data);
    }
}