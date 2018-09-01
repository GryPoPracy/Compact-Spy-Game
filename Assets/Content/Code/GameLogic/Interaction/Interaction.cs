using ActionsSystem;
using Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour, IInteraction
{
    [SerializeField] private ActionList actionList = new ActionList();
    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        EnableSpeiteRenderer(false);
    }

    private void EnableSpeiteRenderer(bool status)
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = status;
    }

    public void Detected()
    {
        Debug.LogFormat("Interaction object {0} detected.", this.gameObject.name);
        EnableSpeiteRenderer(true);
    }

    public void Interact(params object[] data)
    {
        List<object> dataList = new List<object>(data);
        dataList.Add(this);
        actionList.Perform(dataList.ToArray());
        Debug.LogFormat("{0} was used.", gameObject.name);
    }

    public void Leave()
    {
        Debug.LogFormat("Interaction object {0} leaved.", this.gameObject.name);
        EnableSpeiteRenderer(false);
    }

}
