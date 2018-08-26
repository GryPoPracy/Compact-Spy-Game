using Interactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private int instanceId = 0;
    private IInteraction _interaction = null;
    public IInteraction Interaction { get { return _interaction; } }

    private void OnTriggerEnter(Collider other)
    {
        if((_interaction = other.gameObject.GetComponent<IInteraction>()) != null)
        {
            _interaction.Detected();
            instanceId = other.gameObject.GetInstanceID();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetInstanceID() == instanceId)
        {
            _interaction.Leave();
            _interaction = null;
        }
    }
}
