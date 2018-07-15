using ActionsSystem;
using Interactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour, IInteraction
{
    [SerializeField] private ActionList actionList = new ActionList();
    
    public void Interact(params object[] data)
    {
        List<object> dataList = new List<object>(data);
        dataList.Add(this);
        actionList.Perform(dataList.ToArray());
        Debug.LogFormat("{0} was used.", gameObject.name);
    }
}
